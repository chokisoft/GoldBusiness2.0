import axios from 'axios';

// Crear instancia de Axios con configuración
const axiosClient = axios.create({
    baseURL: 'https://localhost:7289/api', // URL de tu API .NET
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    },
    timeout: 30000, // 30 segundos timeout
    withCredentials: false, // Cambia a true si usas cookies
});

// ==================== INTERCEPTOR DE REQUEST ====================
axiosClient.interceptors.request.use(
    (config) => {
        // Agregar token de autenticación si existe
        const token = localStorage.getItem('authToken');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }

        // Log para debugging (solo en desarrollo)
        if (process.env.NODE_ENV === 'development') {
            console.log('🚀 Request:', {
                url: config.url,
                method: config.method,
                data: config.data,
                headers: config.headers
            });
        }

        return config;
    },
    (error) => {
        console.error('❌ Error en request interceptor:', error);
        return Promise.reject(error);
    }
);

// ==================== INTERCEPTOR DE RESPONSE ====================
axiosClient.interceptors.response.use(
    (response) => {
        // Log para debugging (solo en desarrollo)
        if (process.env.NODE_ENV === 'development') {
            console.log('✅ Response:', {
                url: response.config.url,
                status: response.status,
                data: response.data
            });
        }

        // Retornar solo los datos (compatible con tu código)
        return response.data;
    },
    (error) => {
        // ========== DEBUG DETALLADO PARA ERRORES ==========
        console.group('🔴 ERROR DE API DETALLADO');
        console.log('URL:', error.config?.url);
        console.log('Método:', error.config?.method);
        console.log('Status:', error.response?.status);
        console.log('Status Text:', error.response?.statusText);
        console.log('Headers enviados:', error.config?.headers);
        console.log('Datos enviados:', error.config?.data);

        // MOSTRAR EL ERROR COMPLETO DEL BACKEND
        if (error.response?.data) {
            console.log('🔍 Respuesta del backend (ERROR 400):');
            console.log('Tipo:', typeof error.response.data);
            console.log('Contenido:', error.response.data);

            // Intentar parsear si es string
            if (typeof error.response.data === 'string') {
                try {
                    const parsed = JSON.parse(error.response.data);
                    console.log('Parsed:', parsed);
                } catch {
                    console.log('Texto plano:', error.response.data);
                }
            }
        }

        console.groupEnd();

        // ========== MANEJO ESPECÍFICO DE ERROR 400 ==========
        if (error.response?.status === 400) {
            const backendError = error.response.data;

            // Extraer mensaje de error del backend
            let errorMessage = 'Error de validación';

            if (backendError) {
                if (backendError.errors) {
                    // Formato de Validation Problem Details de .NET
                    errorMessage = Object.entries(backendError.errors)
                        .map(([field, errors]) => `${field}: ${errors.join(', ')}`)
                        .join(' | ');
                } else if (backendError.message) {
                    errorMessage = backendError.message;
                } else if (typeof backendError === 'string') {
                    errorMessage = backendError;
                }
            }

            console.error('❌ Error 400 - Detalle:', errorMessage);

            // Mostrar alerta con el error específico
            alert(`Error 400 - Bad Request:\n\n${errorMessage}\n\nRevisa la consola para más detalles.`);

            // Para debugging: mostrar en consola qué se envió
            console.log('📤 Lo que se envió al backend:', JSON.parse(error.config.data || '{}'));
        }

        // ========== MANEJO DE OTROS ERRORES ==========
        if (error.response?.status === 401) {
            console.log('🔐 Token inválido o expirado');
            localStorage.removeItem('authToken');
            localStorage.removeItem('user');

            // Redirigir a login si no estamos ya allí
            if (!window.location.pathname.includes('/login')) {
                setTimeout(() => {
                    window.location.href = '/login';
                }, 1500);
            }
        }

        if (error.response?.status === 404) {
            console.error('❌ Endpoint no encontrado:', error.config.url);
            alert(`Endpoint no encontrado: ${error.config.url}\nVerifica que la ruta exista en tu API .NET`);
        }

        if (error.response?.status === 500) {
            console.error('❌ Error interno del servidor');
            alert('Error interno del servidor. Revisa los logs de tu API .NET');
        }

        if (!error.response) {
            // Error de red o CORS
            console.error('🌐 Error de red/CORS:', error.message);
            alert(`No se puede conectar al servidor.\n\nAsegúrate que:\n1. La API .NET esté corriendo en https://localhost:7289\n2. CORS esté configurado correctamente\n3. No haya problemas de certificado SSL`);
        }

        // ========== PROPAGAR EL ERROR ==========
        return Promise.reject({
            message: error.response?.data?.message || error.message,
            status: error.response?.status,
            statusText: error.response?.statusText,
            data: error.response?.data,
            config: error.config
        });
    }
);

// ==================== FUNCIONES DE UTILIDAD ====================

/**
 * Prueba la conexión con la API
 */
export const testAPIConnection = async () => {
    try {
        console.log('🔍 Probando conexión con API...');
        const response = await axiosClient.get('/'); // Endpoint raíz
        console.log('✅ Conexión exitosa:', response);
        return true;
    } catch (error) {
        console.error('❌ Error de conexión:', error);
        return false;
    }
};

/**
 * Prueba el endpoint de login con diferentes formatos
 * @param {string} email 
 * @param {string} password 
 */
export const testLoginEndpoint = async (email = 'chokisoft@gmail.com', password = 'Choki1972,.!') => {
    console.group('🔍 Probando endpoint /auth/login');

    const testCases = [
        { name: 'Formato 1 (minúscula)', body: { email, password } },
        { name: 'Formato 2 (mayúscula)', body: { Email: email, Password: password } },
        { name: 'Formato 3 (username)', body: { username: email, password } },
        { name: 'Formato 4 (UserName)', body: { UserName: email, Password: password } }
    ];

    for (const testCase of testCases) {
        console.log(`\n📤 ${testCase.name}:`, testCase.body);

        try {
            // Usar fetch directamente para evitar interceptores
            const response = await fetch('https://localhost:7289/api/auth/login', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(testCase.body)
            });

            const data = await response.text();
            console.log(`📥 Respuesta (${response.status}):`, data);

            try {
                const parsed = JSON.parse(data);
                console.log('📋 Parsed JSON:', parsed);
            } catch {
                // No es JSON
            }

        } catch (error) {
            console.error('❌ Error:', error.message);
        }
    }

    console.groupEnd();
};

export default axiosClient;