import { Outlet } from 'react-router-dom';
import { useState } from 'react';
import { styled } from '@mui/material/styles';
import {
    Box, Drawer, CssBaseline, Toolbar, useTheme, useMediaQuery
} from '@mui/material';
import { useAuth } from '../../contexts/AuthContext';
import Navbar from './Navbar';
import Sidebar from './Sidebar';

const drawerWidth = 260;

// Main component modificado para ancho completo
const Main = styled('main', { shouldForwardProp: (prop) => prop !== 'open' })(
    ({ theme, open }) => ({
        flexGrow: 1,
        padding: theme.spacing(3),
        transition: theme.transitions.create('margin', {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen,
        }),
        marginLeft: `-${drawerWidth}px`,
        width: '100%',
        maxWidth: '100%',
        minHeight: 'calc(100vh - 64px)',
        backgroundColor: theme.palette.background.default,
        overflowX: 'hidden',
        position: 'relative',
        ...(open && {
            transition: theme.transitions.create('margin', {
                easing: theme.transitions.easing.easeOut,
                duration: theme.transitions.duration.enteringScreen,
            }),
            marginLeft: 0,
        }),
        [theme.breakpoints.down('md')]: {
            padding: theme.spacing(2),
            marginLeft: 0,
            width: '100%',
        },
        [theme.breakpoints.down('sm')]: {
            padding: theme.spacing(1),
            marginLeft: 0,
            width: '100%',
        },
    }),
);

const DrawerHeader = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(0, 1),
    ...theme.mixins.toolbar,
    justifyContent: 'flex-end',
}));

const MainLayout = () => {
    const [mobileOpen, setMobileOpen] = useState(false);
    const [desktopOpen, setDesktopOpen] = useState(true);
    const { hasPermission } = useAuth();
    const theme = useTheme();
    const isMobile = useMediaQuery(theme.breakpoints.down('md'));

    const handleDrawerToggle = () => {
        if (isMobile) {
            setMobileOpen(!mobileOpen);
        } else {
            setDesktopOpen(!desktopOpen);
        }
    };

    const isDrawerOpen = isMobile ? mobileOpen : desktopOpen;

    return (
        <Box sx={{
            display: 'flex',
            width: '100vw',
            minHeight: '100vh',
            overflowX: 'hidden',
            backgroundColor: theme.palette.background.default
        }}>
            <CssBaseline />

            {/* Navbar */}
            <Navbar
                open={isDrawerOpen}
                handleDrawerToggle={handleDrawerToggle}
                isMobile={isMobile}
            />

            {/* Sidebar */}
            <Drawer
                sx={{
                    width: drawerWidth,
                    flexShrink: 0,
                    '& .MuiDrawer-paper': {
                        width: drawerWidth,
                        boxSizing: 'border-box',
                        position: 'fixed',
                        height: '100vh',
                        overflowY: 'auto',
                    },
                }}
                variant={isMobile ? 'temporary' : 'persistent'}
                anchor="left"
                open={isDrawerOpen}
                onClose={() => isMobile && setMobileOpen(false)}
                ModalProps={{
                    keepMounted: true,
                }}
            >
                <DrawerHeader />
                <Sidebar />
            </Drawer>

            {/* Contenido principal */}
            <Main open={!isMobile && desktopOpen}>
                <Toolbar />
                <Box sx={{
                    width: '100%',
                    maxWidth: '100%',
                    '& > *': {
                        width: '100%',
                        maxWidth: '100%',
                    }
                }}>
                    <Outlet />
                </Box>
            </Main>
        </Box>
    );
};

export default MainLayout;