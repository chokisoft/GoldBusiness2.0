import React from 'react';
import {
    Grid,
    Paper,
    Typography,
    Box,
    Button,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Card,
    CardContent,
    Chip,
    Avatar,
    List,
    ListItem,
    ListItemText,
    ListItemAvatar,
    IconButton,
    useTheme,
    useMediaQuery,
    Container
} from '@mui/material';
import {
    TrendingUp as TrendingUpIcon,
    People as PeopleIcon,
    Inventory as InventoryIcon,
    AttachMoney as MoneyIcon,
    ShoppingCart as CartIcon,
    Notifications as NotificationsIcon,
    MoreVert as MoreVertIcon,
    CheckCircle as CheckCircleIcon,
    Schedule as ScheduleIcon,
    LocalShipping as LocalShippingIcon,
    Warning as WarningIcon,
    BarChart as BarChartIcon,
    Settings as SettingsIcon,
    Add as AddIcon
} from '@mui/icons-material';
import { useAuth } from '../contexts/AuthContext';
import { useNavigate } from 'react-router-dom';

// Componentes de métrica estilizados
const MetricCard = ({ title, value, change, icon, color }) => {
    const theme = useTheme();
    const isMobile = useMediaQuery(theme.breakpoints.down('sm'));

    return (
        <Card sx={{
            height: '100%',
            borderRadius: 2,
            boxShadow: '0 2px 8px rgba(0,0,0,0.08)',
            borderLeft: `4px solid ${color}`,
            transition: 'all 0.3s ease',
            '&:hover': {
                transform: 'translateY(-2px)',
                boxShadow: '0 4px 12px rgba(0,0,0,0.12)'
            }
        }}>
            <CardContent sx={{ p: 2.5 }}>
                <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'flex-start' }}>
                    <Box sx={{ flex: 1 }}>
                        <Typography variant="subtitle2" color="text.secondary" sx={{ mb: 1 }}>
                            {title}
                        </Typography>
                        <Typography variant="h4" sx={{
                            fontWeight: 700,
                            mb: 1,
                            fontSize: { xs: '1.75rem', sm: '2rem' },
                            color: 'text.primary'
                        }}>
                            {value}
                        </Typography>
                        <Box sx={{ display: 'flex', alignItems: 'center', gap: 0.5 }}>
                            <TrendingUpIcon sx={{
                                fontSize: 16,
                                color: change.includes('+') ? '#10b981' : '#ef4444'
                            }} />
                            <Typography variant="body2" sx={{
                                color: change.includes('+') ? '#10b981' : '#ef4444',
                                fontWeight: 500
                            }}>
                                {change}
                            </Typography>
                        </Box>
                    </Box>
                    <Box sx={{
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                        width: 48,
                        height: 48,
                        borderRadius: '12px',
                        backgroundColor: `${color}15`,
                        color: color
                    }}>
                        {icon}
                    </Box>
                </Box>
            </CardContent>
        </Card>
    );
};

// Componente de actividad
const ActivityItem = ({ user, action, time, avatarColor }) => (
    <ListItem sx={{
        px: 0,
        py: 1.5,
        borderBottom: '1px solid',
        borderColor: 'divider'
    }}>
        <ListItemAvatar sx={{ minWidth: 44 }}>
            <Avatar sx={{
                bgcolor: avatarColor || 'primary.main',
                width: 36,
                height: 36
            }}>
                {user.charAt(0)}
            </Avatar>
        </ListItemAvatar>
        <ListItemText
            primary={
                <Typography variant="body2" sx={{ fontWeight: 500 }}>
                    {user}
                </Typography>
            }
            secondary={
                <>
                    <Typography variant="caption" color="text.primary">
                        {action}
                    </Typography>
                    <Typography variant="caption" display="block" color="text.secondary">
                        {time}
                    </Typography>
                </>
            }
        />
    </ListItem>
);

const Dashboard = () => {
    const { user } = useAuth();
    const navigate = useNavigate();
    const theme = useTheme();
    const isMobile = useMediaQuery(theme.breakpoints.down('sm'));
    const isTablet = useMediaQuery(theme.breakpoints.down('md'));

    // Métricas principales
    const metrics = [
        {
            title: 'VENTAS HOY',
            value: '$2,850.00',
            change: '+12.95% ayr',
            icon: <MoneyIcon />,
            color: '#10b981' // verde
        },
        {
            title: 'USUARIOS ACTIVOS',
            value: '24',
            change: '+4.35% ayr',
            icon: <PeopleIcon />,
            color: '#3b82f6' // azul
        },
        {
            title: 'PRODUCTOS EN STOCK',
            value: '1,248',
            change: '+2.15% ayr',
            icon: <InventoryIcon />,
            color: '#8b5cf6' // violeta
        },
        {
            title: 'ÓRDENES PENDIENTES',
            value: '18',
            change: '+5.6% ayr',
            icon: <CartIcon />,
            color: '#f59e0b' // naranja
        }
    ];

    // Actividades recientes
    const activities = [
        { user: 'Crisis Pérez', action: 'Build new wrap per $883.00', time: 'Hace 2 min', color: '#10b981' },
        { user: 'Ana Gerda', action: 'Actualizó Producto X', time: 'Hace 1 min', color: '#3b82f6' },
        { user: 'Luis Martínez', action: 'Nuevo cliente Empresa', time: 'Hace 2 min', color: '#8b5cf6' },
        { user: 'Mark López', action: 'Generó reporte mensual', time: 'Hace 1 hora', color: '#f59e0b' }
    ];

    // Ventas diarias
    const dailySales = [
        { day: 'Lun', sales: '$31,000' },
        { day: 'Mar', sales: '$31,500' },
        { day: 'Mié', sales: '$32,000' },
        { day: 'Jue', sales: '$31,800' },
        { day: 'Vie', sales: '$32,100' },
        { day: 'Sáb', sales: '$32,100' }
    ];

    // Últimos pedidos
    const recentOrders = [
        { id: 'ORD-001', cliente: 'Empresa ABC', fecha: '15 Nov 2024', total: '$1,250.00', estado: 'COMPLETADO' },
        { id: 'ORD-002', cliente: 'Corporación XYZ', fecha: '14 Nov 2024', total: '$3,450.00', estado: 'PENDIENTE' },
        { id: 'ORD-003', cliente: 'Tienda Online', fecha: '13 Nov 2024', total: '$890.00', estado: 'ENVIADO' }
    ];

    return (
        <Container
            maxWidth={false}
            disableGutters
            sx={{
                width: '100%',
                maxWidth: '100% !important',
                p: { xs: 2, sm: 3 },
                m: 0
            }}
        >
            {/* Header del Dashboard */}
            <Box sx={{ mb: 4 }}>
                <Typography variant="h4" sx={{
                    fontWeight: 700,
                    mb: 1,
                    color: 'text.primary'
                }}>
                    Dashboard
                </Typography>
                <Typography variant="body1" color="text.secondary">
                    Bienvenido, {user?.firstName || user?.userName || 'chokisoft@gmail.com'}
                </Typography>
                <Typography variant="caption" color="text.secondary">
                    Free de control (camiño, 14 de diciembre de 2015)
                </Typography>
            </Box>

            {/* Métricas principales */}
            <Grid container spacing={3} sx={{ mb: 4 }}>
                {metrics.map((metric, index) => (
                    <Grid item xs={12} sm={6} lg={3} key={index}>
                        <MetricCard {...metric} />
                    </Grid>
                ))}
            </Grid>

            {/* Sección inferior - 2 columnas */}
            <Grid container spacing={3}>
                {/* Columna izquierda - Tabla y acciones */}
                <Grid item xs={12} lg={8}>
                    <Grid container spacing={3}>
                        {/* Tabla de ventas diarias */}
                        <Grid item xs={12}>
                            <Card sx={{
                                borderRadius: 2,
                                boxShadow: '0 2px 8px rgba(0,0,0,0.08)'
                            }}>
                                <CardContent sx={{ p: 3 }}>
                                    <Box sx={{
                                        display: 'flex',
                                        justifyContent: 'space-between',
                                        alignItems: 'center',
                                        mb: 3
                                    }}>
                                        <Typography variant="h6" sx={{ fontWeight: 600 }}>
                                            VENTAS DIARIAS
                                        </Typography>
                                        <Button
                                            size="small"
                                            variant="outlined"
                                            startIcon={<BarChartIcon />}
                                        >
                                            Ver reporte
                                        </Button>
                                    </Box>

                                    <TableContainer>
                                        <Table size={isMobile ? "small" : "medium"}>
                                            <TableHead>
                                                <TableRow>
                                                    <TableCell sx={{ fontWeight: 600 }}>DÍA</TableCell>
                                                    <TableCell align="right" sx={{ fontWeight: 600 }}>VENTAS</TableCell>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                {dailySales.map((row, index) => (
                                                    <TableRow
                                                        key={index}
                                                        hover
                                                        sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                                    >
                                                        <TableCell component="th" scope="row">
                                                            {row.day}
                                                        </TableCell>
                                                        <TableCell align="right" sx={{ fontWeight: 600, color: 'primary.main' }}>
                                                            {row.sales}
                                                        </TableCell>
                                                    </TableRow>
                                                ))}
                                            </TableBody>
                                        </Table>
                                    </TableContainer>

                                    {/* Resumen */}
                                    <Box sx={{
                                        mt: 3,
                                        p: 2,
                                        bgcolor: 'background.default',
                                        borderRadius: 1,
                                        display: 'flex',
                                        justifyContent: 'space-between',
                                        alignItems: 'center'
                                    }}>
                                        <Typography variant="body2" color="text.secondary">
                                            Total semanal:
                                        </Typography>
                                        <Typography variant="h6" sx={{ fontWeight: 700 }}>
                                            $190,500
                                        </Typography>
                                    </Box>
                                </CardContent>
                            </Card>
                        </Grid>

                        {/* Acciones rápidas */}
                        <Grid item xs={12}>
                            <Card sx={{
                                borderRadius: 2,
                                boxShadow: '0 2px 8px rgba(0,0,0,0.08)'
                            }}>
                                <CardContent sx={{ p: 3 }}>
                                    <Typography variant="h6" sx={{ fontWeight: 600, mb: 3 }}>
                                        ACCIONES RÁPIDAS
                                    </Typography>
                                    <Grid container spacing={2}>
                                        {[
                                            { label: 'Nueva Venta', icon: <MoneyIcon />, color: '#10b981' },
                                            { label: 'Nuevo Producto', icon: <InventoryIcon />, color: '#3b82f6' },
                                            { label: 'Nuevo Cliente', icon: <PeopleIcon />, color: '#8b5cf6' },
                                            { label: 'Generar Reporte', icon: <BarChartIcon />, color: '#f59e0b' }
                                        ].map((action, index) => (
                                            <Grid item xs={6} sm={3} key={index}>
                                                <Button
                                                    fullWidth
                                                    variant="outlined"
                                                    startIcon={action.icon}
                                                    sx={{
                                                        py: 1.5,
                                                        borderColor: 'divider',
                                                        borderRadius: 1,
                                                        '&:hover': {
                                                            borderColor: action.color,
                                                            bgcolor: `${action.color}10`
                                                        }
                                                    }}
                                                >
                                                    {action.label}
                                                </Button>
                                            </Grid>
                                        ))}
                                    </Grid>
                                </CardContent>
                            </Card>
                        </Grid>
                    </Grid>
                </Grid>

                {/* Columna derecha - Actividades */}
                <Grid item xs={12} lg={4}>
                    <Card sx={{
                        height: '100%',
                        borderRadius: 2,
                        boxShadow: '0 2px 8px rgba(0,0,0,0.08)'
                    }}>
                        <CardContent sx={{ p: 3, height: '100%' }}>
                            <Box sx={{
                                display: 'flex',
                                justifyContent: 'space-between',
                                alignItems: 'center',
                                mb: 3
                            }}>
                                <Typography variant="h6" sx={{ fontWeight: 600 }}>
                                    ACTIVIDAD RECIENTE
                                </Typography>
                                <IconButton size="small">
                                    <MoreVertIcon />
                                </IconButton>
                            </Box>

                            <List sx={{ width: '100%', p: 0 }}>
                                {activities.map((activity, index) => (
                                    <ActivityItem key={index} {...activity} />
                                ))}
                            </List>

                            <Button
                                fullWidth
                                variant="text"
                                sx={{ mt: 3 }}
                                onClick={() => navigate('/activities')}
                            >
                                Ver todas las actividades
                            </Button>
                        </CardContent>
                    </Card>
                </Grid>
            </Grid>

            {/* Últimos pedidos */}
            <Box sx={{ mt: 4 }}>
                <Card sx={{
                    borderRadius: 2,
                    boxShadow: '0 2px 8px rgba(0,0,0,0.08)'
                }}>
                    <CardContent sx={{ p: 3 }}>
                        <Typography variant="h6" sx={{ fontWeight: 600, mb: 3 }}>
                            ÚLTIMOS PEDIDOS
                        </Typography>

                        <TableContainer>
                            <Table size={isMobile ? "small" : "medium"}>
                                <TableHead>
                                    <TableRow>
                                        <TableCell sx={{ fontWeight: 600 }}>PEDIDO</TableCell>
                                        <TableCell sx={{ fontWeight: 600 }}>CLIENTE</TableCell>
                                        <TableCell sx={{ fontWeight: 600 }}>FECHA</TableCell>
                                        <TableCell sx={{ fontWeight: 600 }}>TOTAL</TableCell>
                                        <TableCell sx={{ fontWeight: 600 }}>ESTADO</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {recentOrders.map((order, index) => (
                                        <TableRow key={index} hover>
                                            <TableCell sx={{ fontWeight: 500 }}>{order.id}</TableCell>
                                            <TableCell>{order.cliente}</TableCell>
                                            <TableCell>{order.fecha}</TableCell>
                                            <TableCell sx={{ fontWeight: 600 }}>{order.total}</TableCell>
                                            <TableCell>
                                                <Chip
                                                    label={order.estado}
                                                    size="small"
                                                    sx={{
                                                        bgcolor:
                                                            order.estado === 'COMPLETADO' ? '#10b98120' :
                                                                order.estado === 'PENDIENTE' ? '#f59e0b20' :
                                                                    '#3b82f620',
                                                        color:
                                                            order.estado === 'COMPLETADO' ? '#10b981' :
                                                                order.estado === 'PENDIENTE' ? '#f59e0b' :
                                                                    '#3b82f6',
                                                        fontWeight: 500,
                                                        borderRadius: 1
                                                    }}
                                                />
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </CardContent>
                </Card>
            </Box>
        </Container>
    );
};

export default Dashboard;