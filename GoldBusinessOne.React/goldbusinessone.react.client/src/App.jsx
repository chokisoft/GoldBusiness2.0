// App.jsx
import React from 'react';
import {
    Box,
    Grid,
    Card,
    CardContent,
    Typography,
    Container,
    AppBar,
    Toolbar,
    IconButton,
    Drawer,
    List,
    ListItem,
    ListItemButton,
    ListItemIcon,
    ListItemText,
    useTheme,
    useMediaQuery,
} from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import DashboardIcon from '@mui/icons-material/Dashboard';
import InventoryIcon from '@mui/icons-material/Inventory';
import CategoryIcon from '@mui/icons-material/Category';
import ReceiptIcon from '@mui/icons-material/Receipt';
import PeopleIcon from '@mui/icons-material/People';
import SettingsIcon from '@mui/icons-material/Settings';
import BarChartIcon from '@mui/icons-material/BarChart';
import TrendingUpIcon from '@mui/icons-material/TrendingUp';
import PersonIcon from '@mui/icons-material/Person';
import StoreIcon from '@mui/icons-material/Store';
import { styled } from '@mui/material/styles';

const drawerWidth = 240;

const StyledCard = styled(Card)(({ theme }) => ({
    height: '100%',
    display: 'flex',
    flexDirection: 'column',
    transition: 'transform 0.3s ease-in-out',
    '&:hover': {
        transform: 'translateY(-4px)',
        boxShadow: theme.shadows[8],
    },
}));

const MetricValue = styled(Typography)(({ theme }) => ({
    fontSize: '2.5rem',
    fontWeight: 700,
    color: theme.palette.primary.main,
    margin: theme.spacing(2, 0),
}));

const MetricChange = styled(Typography)(({ theme }) => ({
    color: theme.palette.success.main,
    fontWeight: 500,
}));

function App() {
    const theme = useTheme();
    const isMobile = useMediaQuery(theme.breakpoints.down('md'));
    const [mobileOpen, setMobileOpen] = React.useState(false);

    const handleDrawerToggle = () => {
        setMobileOpen(!mobileOpen);
    };

    const menuItems = [
        { text: 'Veritas', icon: <DashboardIcon /> },
        { text: 'Inventario', icon: <InventoryIcon /> },
        { text: 'Productos', icon: <StoreIcon /> },
        { text: 'Categorías', icon: <CategoryIcon /> },
        { text: 'Previoletas', icon: <ReceiptIcon /> },
        { text: 'Movimientos', icon: <TrendingUpIcon /> },
        { text: 'Reportes', icon: <BarChartIcon /> },
        { text: 'Configuración', icon: <SettingsIcon /> },
    ];

    const drawer = (
        <Box sx={{ pt: 8 }}>
            <List>
                {menuItems.map((item) => (
                    <ListItem key={item.text} disablePadding>
                        <ListItemButton>
                            <ListItemIcon>{item.icon}</ListItemIcon>
                            <ListItemText primary={item.text} />
                        </ListItemButton>
                    </ListItem>
                ))}
            </List>
        </Box>
    );

    return (
        <Box sx={{ display: 'flex', minHeight: '100vh' }}>
            {/* AppBar para móviles */}
            <AppBar
                position="fixed"
                sx={{
                    width: { sm: `calc(100% - ${drawerWidth}px)` },
                    ml: { sm: `${drawerWidth}px` },
                }}
            >
                <Toolbar>
                    {isMobile && (
                        <IconButton
                            color="inherit"
                            aria-label="open drawer"
                            edge="start"
                            onClick={handleDrawerToggle}
                            sx={{ mr: 2 }}
                        >
                            <MenuIcon />
                        </IconButton>
                    )}
                    <Typography variant="h6" noWrap component="div" sx={{ flexGrow: 1 }}>
                        Dashboard
                    </Typography>
                    <Box sx={{ display: 'flex', alignItems: 'center', gap: 2 }}>
                        <PersonIcon />
                        <Box>
                            <Typography variant="body2">Bienvenido, chokisoft@gmail.com</Typography>
                            <Typography variant="caption">Free de control (camiño, 14 de diciembre de 2015)</Typography>
                        </Box>
                    </Box>
                </Toolbar>
            </AppBar>

            {/* Drawer para navegación */}
            <Box
                component="nav"
                sx={{ width: { sm: drawerWidth }, flexShrink: { sm: 0 } }}
            >
                {isMobile ? (
                    <Drawer
                        variant="temporary"
                        open={mobileOpen}
                        onClose={handleDrawerToggle}
                        ModalProps={{ keepMounted: true }}
                    >
                        {drawer}
                    </Drawer>
                ) : (
                    <Drawer
                        variant="permanent"
                        sx={{
                            '& .MuiDrawer-paper': {
                                width: drawerWidth,
                                boxSizing: 'border-box',
                            },
                        }}
                        open
                    >
                        {drawer}
                    </Drawer>
                )}
            </Box>

            {/* Contenido principal */}
            <Box
                component="main"
                sx={{
                    flexGrow: 1,
                    p: 3,
                    width: { sm: `calc(100% - ${drawerWidth}px)` },
                    mt: 8, // Para compensar el AppBar
                }}
            >
                <Container maxWidth="xl" disableGutters>
                    {/* Métricas principales */}
                    <Grid container spacing={3} sx={{ mb: 4 }}>
                        <Grid item xs={12} sm={6} md={4}>
                            <StyledCard>
                                <CardContent sx={{ textAlign: 'center' }}>
                                    <Typography variant="h6" color="textSecondary" gutterBottom>
                                        Ventas Hoy
                                    </Typography>
                                    <MetricValue>$2,850.00</MetricValue>
                                    <MetricChange>
                                        <TrendingUpIcon sx={{ fontSize: 16, verticalAlign: 'text-bottom' }} />
                                        +12.95% ayr
                                    </MetricChange>
                                </CardContent>
                            </StyledCard>
                        </Grid>

                        <Grid item xs={12} sm={6} md={4}>
                            <StyledCard>
                                <CardContent sx={{ textAlign: 'center' }}>
                                    <Typography variant="h6" color="textSecondary" gutterBottom>
                                        Usuarios Activos
                                    </Typography>
                                    <MetricValue>24</MetricValue>
                                    <MetricChange>
                                        <TrendingUpIcon sx={{ fontSize: 16, verticalAlign: 'text-bottom' }} />
                                        +4.35% ayr
                                    </MetricChange>
                                </CardContent>
                            </StyledCard>
                        </Grid>

                        <Grid item xs={12} sm={6} md={4}>
                            <StyledCard>
                                <CardContent sx={{ textAlign: 'center' }}>
                                    <Typography variant="h6" color="textSecondary" gutterBottom>
                                        Productos en Stock
                                    </Typography>
                                    <MetricValue>1,248</MetricValue>
                                    <MetricChange>
                                        <TrendingUpIcon sx={{ fontSize: 16, verticalAlign: 'text-bottom' }} />
                                        +2.15% ayr
                                    </MetricChange>
                                </CardContent>
                            </StyledCard>
                        </Grid>
                    </Grid>

                    {/* Sección inferior */}
                    <Grid container spacing={3}>
                        {/* Acciones rápidas */}
                        <Grid item xs={12} md={4}>
                            <StyledCard>
                                <CardContent>
                                    <Typography variant="h6" gutterBottom>
                                        Acciones Rápidas
                                    </Typography>
                                    <Typography variant="body2" color="textSecondary" paragraph>
                                        Ventas últimos 7 días
                                    </Typography>
                                    {/* Puedes agregar botones de acción aquí */}
                                </CardContent>
                            </StyledCard>
                        </Grid>

                        {/* Actividad reciente */}
                        <Grid item xs={12} md={4}>
                            <StyledCard>
                                <CardContent>
                                    <Typography variant="h6" gutterBottom>
                                        Actividad Reciente
                                    </Typography>
                                    <List dense>
                                        {[
                                            { user: 'Crisis Pérez', action: 'Build new wrap per $883.00', time: '2 min' },
                                            { user: 'Ana Gerda', action: 'Actualizó Producto X', time: '1 min' },
                                            { user: 'Luis Martínez', action: 'Nuevo cliente Empresa', time: '2 min' },
                                        ].map((item, index) => (
                                            <ListItem key={index} disablePadding sx={{ mb: 1 }}>
                                                <Box sx={{ width: '100%' }}>
                                                    <Typography variant="subtitle2">{item.user}</Typography>
                                                    <Typography variant="body2" color="textSecondary">
                                                        {item.action}
                                                    </Typography>
                                                    <Typography variant="caption" color="textSecondary">
                                                        Hace {item.time}
                                                    </Typography>
                                                </Box>
                                            </ListItem>
                                        ))}
                                    </List>
                                </CardContent>
                            </StyledCard>
                        </Grid>

                        {/* Ventas diarias */}
                        <Grid item xs={12} md={4}>
                            <StyledCard>
                                <CardContent>
                                    <Typography variant="h6" gutterBottom>
                                        Ventas Diarias
                                    </Typography>
                                    <Box sx={{ overflowX: 'auto' }}>
                                        <Box component="table" sx={{ width: '100%', borderCollapse: 'collapse' }}>
                                            <thead>
                                                <tr>
                                                    <th style={{ textAlign: 'left', padding: '8px', borderBottom: '1px solid #e0e0e0' }}>Día</th>
                                                    <th style={{ textAlign: 'left', padding: '8px', borderBottom: '1px solid #e0e0e0' }}>Ventas</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {[
                                                    { day: 'Lun', sales: '$31,000' },
                                                    { day: 'Mar', sales: '$31,500' },
                                                    { day: 'Mié', sales: '$32,000' },
                                                    { day: 'Jue', sales: '$31,800' },
                                                    { day: 'Vie', sales: '$32,100' },
                                                    { day: 'Sáb', sales: '$32,100' },
                                                ].map((row, index) => (
                                                    <tr key={index}>
                                                        <td style={{ padding: '8px', borderBottom: '1px solid #f0f0f0' }}>{row.day}</td>
                                                        <td style={{ padding: '8px', borderBottom: '1px solid #f0f0f0' }}>{row.sales}</td>
                                                    </tr>
                                                ))}
                                            </tbody>
                                        </Box>
                                    </Box>
                                </CardContent>
                            </StyledCard>
                        </Grid>
                    </Grid>
                </Container>
            </Box>
        </Box>
    );
}

export default App;