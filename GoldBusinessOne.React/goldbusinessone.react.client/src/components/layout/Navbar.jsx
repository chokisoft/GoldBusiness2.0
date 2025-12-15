import { useState } from 'react';
import {
    AppBar, Toolbar, Typography, IconButton,
    Box, Avatar, Menu, MenuItem, Badge,
    InputBase, alpha, Button
} from '@mui/material';
import {
    Menu as MenuIcon,
    Notifications as NotificationsIcon,
    Person as PersonIcon,
    Logout as LogoutIcon,
    Settings as SettingsIcon,
    Search as SearchIcon,
    Dashboard as DashboardIcon,
    ExitToApp as ExitToAppIcon
} from '@mui/icons-material';
import { styled } from '@mui/material/styles';
import { useAuth } from '../../contexts/AuthContext';
import { useNavigate } from 'react-router-dom';

// Barra de búsqueda estilo Bootstrap
const Search = styled('div')(({ theme }) => ({
    position: 'relative',
    borderRadius: theme.shape.borderRadius,
    backgroundColor: alpha(theme.palette.common.white, 0.15),
    '&:hover': {
        backgroundColor: alpha(theme.palette.common.white, 0.25),
    },
    marginRight: theme.spacing(2),
    marginLeft: 0,
    width: '100%',
    [theme.breakpoints.up('sm')]: {
        marginLeft: theme.spacing(3),
        width: 'auto',
    },
}));

const SearchIconWrapper = styled('div')(({ theme }) => ({
    padding: theme.spacing(0, 2),
    height: '100%',
    position: 'absolute',
    pointerEvents: 'none',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
    color: 'inherit',
    '& .MuiInputBase-input': {
        padding: theme.spacing(1, 1, 1, 0),
        paddingLeft: `calc(1em + ${theme.spacing(4)})`,
        transition: theme.transitions.create('width'),
        width: '100%',
        [theme.breakpoints.up('md')]: {
            width: '20ch',
        },
    },
}));

const Navbar = ({ open, handleDrawerToggle }) => {
    const [anchorEl, setAnchorEl] = useState(null);
    const { user, logout } = useAuth();
    const navigate = useNavigate();

    const handleMenuOpen = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handleMenuClose = () => {
        setAnchorEl(null);
    };

    const handleLogout = () => {
        logout();
        navigate('/login');
    };

    const handleProfile = () => {
        navigate('/profile');
        handleMenuClose();
    };

    const handleSettings = () => {
        navigate('/settings');
        handleMenuClose();
    };

    return (
        <AppBar position="fixed" sx={{ zIndex: (theme) => theme.zIndex.drawer + 1 }}>
            <Toolbar>
                {/* Logo y título - Réplica del navbar .NET */}
                <Box sx={{ display: 'flex', alignItems: 'center', flexGrow: 1 }}>
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        onClick={handleDrawerToggle}
                        edge="start"
                        sx={{ mr: 2 }}
                    >
                        <MenuIcon />
                    </IconButton>

                    <DashboardIcon sx={{ mr: 1, fontSize: 28 }} />

                    <Typography variant="h6" noWrap component="div" sx={{ fontWeight: 'bold' }}>
                        Gold Business
                        <Typography component="span" variant="caption" sx={{ ml: 1, opacity: 0.8 }}>
                            v2.0
                        </Typography>
                    </Typography>
                </Box>

                {/* Barra de búsqueda (opcional) */}
                <Search sx={{ display: { xs: 'none', md: 'flex' } }}>
                    <SearchIconWrapper>
                        <SearchIcon />
                    </SearchIconWrapper>
                    <StyledInputBase
                        placeholder="Buscar en el sistema…"
                        inputProps={{ 'aria-label': 'search' }}
                    />
                </Search>

                {/* Notificaciones */}
                <IconButton color="inherit" sx={{ mr: 1 }}>
                    <Badge badgeContent={3} color="secondary">
                        <NotificationsIcon />
                    </Badge>
                </IconButton>

                {/* Usuario y menú */}
                <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                    <Avatar
                        sx={{
                            width: 32,
                            height: 32,
                            bgcolor: 'secondary.main',
                            cursor: 'pointer'
                        }}
                        onClick={handleMenuOpen}
                    >
                        {user?.firstName?.[0] || user?.userName?.[0] || <PersonIcon />}
                    </Avatar>

                    <Box sx={{ display: { xs: 'none', sm: 'flex' }, flexDirection: 'column' }}>
                        <Typography variant="body2" fontWeight="bold">
                            {user?.firstName || user?.userName || 'Usuario'}
                        </Typography>
                        <Typography variant="caption" sx={{ opacity: 0.8 }}>
                            {user?.roles?.[0] || 'Administrador'}
                        </Typography>
                    </Box>
                </Box>

                {/* Menú desplegable */}
                <Menu
                    anchorEl={anchorEl}
                    open={Boolean(anchorEl)}
                    onClose={handleMenuClose}
                    PaperProps={{
                        sx: {
                            mt: 1.5,
                            minWidth: 200,
                        }
                    }}
                >
                    <MenuItem sx={{ fontWeight: 'bold', color: 'text.secondary' }}>
                        {user?.email || 'chokisoft@gmail.com'}
                    </MenuItem>
                    <MenuItem onClick={handleProfile}>
                        <PersonIcon sx={{ mr: 1 }} fontSize="small" />
                        Mi Perfil
                    </MenuItem>
                    <MenuItem onClick={handleSettings}>
                        <SettingsIcon sx={{ mr: 1 }} fontSize="small" />
                        Configuración
                    </MenuItem>
                    <MenuItem onClick={handleLogout} sx={{ color: 'error.main' }}>
                        <ExitToAppIcon sx={{ mr: 1 }} fontSize="small" />
                        Cerrar Sesión
                    </MenuItem>
                </Menu>
            </Toolbar>
        </AppBar>
    );
};

export default Navbar;