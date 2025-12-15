import React, { createContext, useState, useContext, useEffect } from 'react';
import axiosClient from '../api/axiosClient';

// 1. Crear el contexto
const AuthContext = createContext(null);

// 2. Hook personalizado para usar el contexto
export const useAuth = () => {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error('useAuth debe ser usado dentro de un AuthProvider');
    }
    return context;
};

// 3. Proveedor del contexto
export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [permissions, setPermissions] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    // Cargar usuario desde localStorage al iniciar
    useEffect(() => {
        const token = localStorage.getItem('authToken');
        const storedUser = localStorage.getItem('user');

        if (token && storedUser) {
            try {
                const userData = JSON.parse(storedUser);
                setUser(userData);
                console.log('🔄 Usuario cargado desde localStorage:', userData);
            } catch (e) {
                console.error('Error parseando usuario:', e);
                localStorage.removeItem('authToken');
                localStorage.removeItem('user');
            }
        }

        setLoading(false);
    }, []);

    // Función de login - VERSIÓN CORREGIDA
    const login = async (email, password) => {
        try {
            setError(null);
            setLoading(true);

            console.log('🔐 Intentando login con:', email);

            // Formato que funciona según logs
            const body = {
                userName: email,  // Tu API espera 'userName'
                password: password
            };

            console.log('📤 Enviando:', body);

            const response = await axiosClient.post('/auth/login', body);
            console.log('✅ Login exitoso, respuesta completa:', response);

            const { token, ...userData } = response;

            if (!token) {
                throw new Error('No se recibió token del servidor');
            }

            // Guardar token y datos de usuario
            localStorage.setItem('authToken', token);
            localStorage.setItem('user', JSON.stringify(userData));

            console.log('✅ Token y usuario guardados en localStorage');
            console.log('📊 Datos del usuario:', userData);

            // ACTUALIZAR ESTADO INMEDIATAMENTE - ESTO ES CRÍTICO
            setUser(userData);
            setPermissions([]); // Por ahora sin permisos
            setError(null);

            // Retornar datos para el componente
            return { token, user: userData };

        } catch (error) {
            console.error('❌ Error en login:', error);

            let errorMsg = 'Error de autenticación';

            if (error.status === 401) {
                errorMsg = 'Credenciales inválidas';
            } else if (error.status === 404) {
                errorMsg = 'Endpoint no encontrado';
            } else if (error.message.includes('Network')) {
                errorMsg = 'No se puede conectar al servidor';
            }

            setError(errorMsg);
            throw error;
        } finally {
            setLoading(false);
        }
    };

    // Función de logout
    const logout = () => {
        console.log('🚪 Cerrando sesión...');
        localStorage.removeItem('authToken');
        localStorage.removeItem('user');
        setUser(null);
        setPermissions([]);
        setError(null);

        // Redirigir a login
        window.location.href = '/login';
    };

    // Verificar permisos
    const hasPermission = (permission) => {
        return !!user; // Por ahora, si hay usuario tiene permisos
    };

    const hasAnyPermission = (permissionList) => {
        if (!permissionList || permissionList.length === 0) return true;
        return permissionList.some(perm => hasPermission(perm));
    };

    // Obtener token actual
    const getToken = () => {
        return localStorage.getItem('authToken');
    };

    // Estado actual de autenticación
    const isAuthenticated = !!user;

    // Valor del contexto
    const contextValue = {
        user,
        permissions,
        loading,
        error,
        login,
        logout,
        hasPermission,
        hasAnyPermission,
        getToken,
        isAuthenticated
    };

    return (
        <AuthContext.Provider value={contextValue}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthContext;