import { List, ListItem, ListItemButton, ListItemIcon, ListItemText, Collapse } from '@mui/material';
import { useNavigate, useLocation } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';
import {
    Dashboard as DashboardIcon,
    People as PeopleIcon,
    Inventory as InventoryIcon,
    PointOfSale as PointOfSaleIcon,
    Assessment as AssessmentIcon,
    Settings as SettingsIcon,
    AccountCircle as AccountCircleIcon,
    ChevronRight as ChevronRightIcon,
    ExpandMore as ExpandMoreIcon,
    Security as SecurityIcon,
    Receipt as ReceiptIcon,
    Category as CategoryIcon,
    Store as StoreIcon
} from '@mui/icons-material';
import { useState } from 'react';

const Sidebar = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const { hasPermission } = useAuth();

    // Estado para submenús desplegables
    const [openMenus, setOpenMenus] = useState({});

    // Menú principal - Réplica de tu .NET
    const menuItems = [
        {
            text: 'Dashboard',
            icon: <DashboardIcon />,
            path: '/dashboard',
            perm: 'perm.dashboard'
        },
        {
            text: 'Usuarios',
            icon: <PeopleIcon />,
            path: '/users',
            perm: 'perm.users'
        },
        {
            text: 'Ventas',
            icon: <PointOfSaleIcon />,
            children: [
                { text: 'Nueva Venta', path: '/sales/new' },
                { text: 'Historial', path: '/sales/history' },
                { text: 'Clientes', path: '/sales/customers' },
            ],
            perm: 'perm.sales'
        },
        {
            text: 'Inventario',
            icon: <InventoryIcon />,
            children: [
                { text: 'Productos', path: '/inventory/products' },
                { text: 'Categorías', path: '/inventory/categories' },
                { text: 'Proveedores', path: '/inventory/suppliers' },
                { text: 'Movimientos', path: '/inventory/movements' },
            ],
            perm: 'perm.inventory'
        },
        {
            text: 'Reportes',
            icon: <AssessmentIcon />,
            children: [
                { text: 'Ventas', path: '/reports/sales' },
                { text: 'Inventario', path: '/reports/inventory' },
                { text: 'Financieros', path: '/reports/financial' },
            ],
            perm: 'perm.reports'
        },
        {
            text: 'Configuración',
            icon: <SettingsIcon />,
            path: '/settings',
            perm: 'perm.settings'
        },
    ];

    const handleMenuClick = (item) => {
        if (item.children) {
            setOpenMenus(prev => ({
                ...prev,
                [item.text]: !prev[item.text]
            }));
        } else if (item.path) {
            navigate(item.path);
        }
    };

    const isActive = (path) => {
        return location.pathname === path;
    };

    // Filtrar menú según permisos
    const filteredMenuItems = menuItems.filter(item =>
        !item.perm || hasPermission(item.perm)
    );

    return (
        <List sx={{ pt: 2 }}>
            {filteredMenuItems.map((item) => (
                <div key={item.text}>
                    <ListItem disablePadding>
                        <ListItemButton
                            selected={isActive(item.path)}
                            onClick={() => handleMenuClick(item)}
                            sx={{
                                py: 1,
                                px: 3,
                                '&.Mui-selected': {
                                    backgroundColor: 'primary.main',
                                    '&:hover': {
                                        backgroundColor: 'primary.dark',
                                    },
                                },
                                '&:hover': {
                                    backgroundColor: 'rgba(255, 255, 255, 0.1)',
                                },
                            }}
                        >
                            <ListItemIcon sx={{ color: 'inherit', minWidth: 40 }}>
                                {item.icon}
                            </ListItemIcon>
                            <ListItemText
                                primary={item.text}
                                primaryTypographyProps={{
                                    fontSize: '0.875rem',
                                    fontWeight: isActive(item.path) ? 600 : 400,
                                }}
                            />
                            {item.children && (
                                openMenus[item.text] ?
                                    <ExpandMoreIcon fontSize="small" /> :
                                    <ChevronRightIcon fontSize="small" />
                            )}
                        </ListItemButton>
                    </ListItem>

                    {/* Submenú desplegable */}
                    {item.children && openMenus[item.text] && (
                        <Collapse in={openMenus[item.text]} timeout="auto" unmountOnExit>
                            <List component="div" disablePadding>
                                {item.children.map((child) => (
                                    <ListItemButton
                                        key={child.text}
                                        sx={{
                                            pl: 8,
                                            py: 0.75,
                                            fontSize: '0.8rem',
                                            '&:hover': {
                                                backgroundColor: 'rgba(255, 255, 255, 0.05)',
                                            },
                                        }}
                                        onClick={() => navigate(child.path)}
                                    >
                                        <ListItemText
                                            primary={child.text}
                                            primaryTypographyProps={{
                                                fontSize: '0.8rem',
                                                color: 'rgba(255, 255, 255, 0.7)',
                                            }}
                                        />
                                    </ListItemButton>
                                ))}
                            </List>
                        </Collapse>
                    )}
                </div>
            ))}
        </List>
    );
};

export default Sidebar;