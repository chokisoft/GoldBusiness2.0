import { Navigate, useLocation } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';
import { CircularProgress, Box, Typography, Paper } from '@mui/material';
import { Lock as LockIcon } from '@mui/icons-material';

const ProtectedRoute = ({ children, requiredPermissions = [] }) => {
    const { user, loading, hasAnyPermission, isAuthenticated } = useAuth();
    const location = useLocation();

    console.log('🛡️ ProtectedRoute - Verificando acceso:', {
        ruta: location.pathname,
        loading,
        isAuthenticated,
        usuario: user?.email,
        permisosRequeridos: requiredPermissions
    });

    // 1. Mostrar carga mientras se verifica
    if (loading) {
        return (
            <Box sx={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                height: '100vh',
                flexDirection: 'column',
                backgroundColor: '#f5f5f5'
            }}>
                <CircularProgress size={60} thickness={4} />
                <Typography variant="h6" sx={{ mt: 3, color: 'text.secondary' }}>
                    Verificando acceso...
                </Typography>
                <Typography variant="body2" sx={{ mt: 1, color: 'text.secondary' }}>
                    Por favor espera
                </Typography>
            </Box>
        );
    }

    // 2. Si no está autenticado, redirigir a login
    if (!isAuthenticated) {
        console.log('🔐 Acceso denegado: Usuario no autenticado');
        console.log('📍 Redirigiendo a /login desde:', location.pathname);

        // Guardar la ruta a la que intentaba acceder para redirigir después del login
        const redirectPath = location.pathname !== '/login' ? location.pathname : '/dashboard';
        sessionStorage.setItem('redirectAfterLogin', redirectPath);

        return <Navigate to="/login" state={{ from: location }} replace />;
    }

    // 3. Verificar permisos específicos si se requieren
    if (requiredPermissions.length > 0 && !hasAnyPermission(requiredPermissions)) {
        console.log('🚫 Acceso denegado: Permisos insuficientes');
        console.log('Permisos requeridos:', requiredPermissions);
        console.log('Usuario actual:', user);

        return (
            <Box sx={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                height: '100vh',
                backgroundColor: '#f5f5f5'
            }}>
                <Paper elevation={3} sx={{ p: 4, maxWidth: 500, textAlign: 'center' }}>
                    <LockIcon sx={{ fontSize: 60, color: 'error.main', mb: 2 }} />
                    <Typography variant="h5" gutterBottom>
                        Acceso Denegado
                    </Typography>
                    <Typography variant="body1" color="text.secondary" paragraph>
                        No tienes los permisos necesarios para acceder a esta sección.
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Contacta al administrador si necesitas acceso.
                    </Typography>
                    <Box sx={{ mt: 3 }}>
                        <a href="/dashboard" style={{ textDecoration: 'none' }}>
                            <Typography variant="body2" color="primary">
                                ← Volver al Dashboard
                            </Typography>
                        </a>
                    </Box>
                </Paper>
            </Box>
        );
    }

    // 4. Acceso autorizado
    console.log('✅ Acceso autorizado a:', location.pathname);
    return children;
};

export default ProtectedRoute;