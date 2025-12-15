import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import {
    TextField,
    Button,
    Container,
    Typography,
    Box,
    Alert,
    CircularProgress,
    Paper
} from '@mui/material';
import { Lock as LockIcon } from '@mui/icons-material';
import { useAuth } from '../contexts/AuthContext';

const Login = () => {
    const [email, setEmail] = useState('chokisoft@gmail.com');
    const [password, setPassword] = useState('Choki1972,.'); // ← SIN ! al final
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [loginError, setLoginError] = useState(''); // Estado local para errores
    const { login, error: authError, isAuthenticated } = useAuth();
    const navigate = useNavigate();

    // Efecto para redirigir si ya está autenticado
    useEffect(() => {
        if (isAuthenticated) {
            console.log('✅ Usuario ya autenticado, redirigiendo a dashboard...');
            navigate('/dashboard', { replace: true });
        }
    }, [isAuthenticated, navigate]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        setIsSubmitting(true);
        setLoginError('');

        try {
            console.log('🔄 Iniciando proceso de login...');
            await login(email, password);
            console.log('✅ Login completado en AuthContext');

            // La redirección ahora se maneja en el useEffect arriba
            // porque isAuthenticated cambiará después del login

        } catch (error) {
            console.error('❌ Error de login en componente:', error);
            setLoginError(error.message || 'Error de autenticación');
        } finally {
            setIsSubmitting(false);
        }
    };

    const handleDemoLogin = () => {
        setEmail('chokisoft@gmail.com');
        setPassword('Choki1972,.'); // ← SIN ! al final
    };

    // Mostrar error de AuthContext o error local
    const displayError = authError || loginError;

    return (
        <Container maxWidth="sm" sx={{ height: '100vh', display: 'flex', alignItems: 'center' }}>
            <Paper elevation={3} sx={{ width: '100%', p: 4 }}>
                <Box sx={{
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                    mb: 4
                }}>
                    <LockIcon sx={{ fontSize: 40, color: 'primary.main', mb: 2 }} />
                    <Typography component="h1" variant="h5" sx={{ mb: 1 }}>
                        Gold Business
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Sistema de Gestión Empresarial
                    </Typography>
                </Box>

                {displayError && (
                    <Alert severity="error" sx={{ mb: 3 }}>
                        {displayError}
                    </Alert>
                )}

                <Box component="form" onSubmit={handleSubmit} sx={{ width: '100%' }}>
                    <TextField
                        margin="normal"
                        required
                        fullWidth
                        label="Correo Electrónico"
                        autoComplete="email"
                        autoFocus
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        disabled={isSubmitting}
                        helperText="Se usará como userName"
                    />
                    <TextField
                        margin="normal"
                        required
                        fullWidth
                        label="Contraseña"
                        type="password"
                        autoComplete="current-password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        disabled={isSubmitting}
                        helperText="Contraseña: Choki1972,."
                    />

                    <Button
                        type="submit"
                        fullWidth
                        variant="contained"
                        disabled={isSubmitting}
                        sx={{ mt: 3, mb: 2, py: 1.5 }}
                    >
                        {isSubmitting ? (
                            <CircularProgress size={24} color="inherit" />
                        ) : (
                            'Iniciar Sesión'
                        )}
                    </Button>

                    <Button
                        fullWidth
                        variant="outlined"
                        onClick={handleDemoLogin}
                        disabled={isSubmitting}
                        sx={{ mb: 2 }}
                    >
                        Usar Credenciales de Demo
                    </Button>
                </Box>

                <Box sx={{ mt: 3, textAlign: 'center' }}>
                    <Typography variant="body2" color="text.secondary">
                        Estado: {isAuthenticated ? '✅ Autenticado' : '🔓 No autenticado'}
                    </Typography>
                    <Typography variant="caption" color="text.secondary" component="div">
                        Token: {localStorage.getItem('authToken') ? '✅ Presente' : '❌ Ausente'}
                    </Typography>
                </Box>
            </Paper>
        </Container>
    );
};

export default Login;