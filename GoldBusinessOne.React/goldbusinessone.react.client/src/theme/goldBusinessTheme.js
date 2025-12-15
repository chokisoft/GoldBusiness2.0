import { createTheme } from '@mui/material/styles';

// Réplica EXACTA de los colores de GoldBusinessOne (.NET)
const goldBusinessTheme = createTheme({
    palette: {
        // Paleta principal basada en tu proyecto .NET
        primary: {
            main: '#1e4a7b',      // Azul principal del navbar
            light: '#4a76b3',
            dark: '#0d2c52',
            contrastText: '#ffffff',
        },
        secondary: {
            main: '#6c757d',      // Gris Bootstrap secundario
            light: '#9fa6ad',
            dark: '#495057',
            contrastText: '#ffffff',
        },
        success: {
            main: '#198754',      // Verde Bootstrap success
            light: '#479f76',
            dark: '#0f5132',
        },
        info: {
            main: '#0dcaf0',      // Azul claro Bootstrap info
            light: '#5dd4f4',
            dark: '#0aa2c0',
        },
        warning: {
            main: '#ffc107',      // Amarillo Bootstrap warning
            light: '#ffcd39',
            dark: '#b28704',
        },
        error: {
            main: '#dc3545',      // Rojo Bootstrap danger
            light: '#e35d6a',
            dark: '#9a2530',
        },
        background: {
            default: '#f8f9fa',   // Fondo gris claro (bg-light de Bootstrap)
            paper: '#ffffff',      // Fondo blanco de cards
        },
        text: {
            primary: '#212529',    // Texto oscuro Bootstrap
            secondary: '#6c757d',  // Texto gris secundario
        },
        grey: {
            100: '#f8f9fa',
            200: '#e9ecef',
            300: '#dee2e6',
            400: '#ced4da',
            500: '#adb5bd',
            600: '#6c757d',
            700: '#495057',
            800: '#343a40',
            900: '#212529',
        },
    },
    typography: {
        fontFamily: [
            '-apple-system',
            'BlinkMacSystemFont',
            '"Segoe UI"',
            'Roboto',
            '"Helvetica Neue"',
            'Arial',
            'sans-serif',
            '"Apple Color Emoji"',
            '"Segoe UI Emoji"',
            '"Segoe UI Symbol"'
        ].join(','),
        h1: {
            fontSize: '2.5rem',
            fontWeight: 500,
            color: '#212529',
        },
        h2: {
            fontSize: '2rem',
            fontWeight: 500,
            color: '#212529',
        },
        h3: {
            fontSize: '1.75rem',
            fontWeight: 500,
            color: '#212529',
        },
        h4: {
            fontSize: '1.5rem',
            fontWeight: 500,
            color: '#212529',
        },
        h5: {
            fontSize: '1.25rem',
            fontWeight: 500,
            color: '#212529',
        },
        h6: {
            fontSize: '1rem',
            fontWeight: 500,
            color: '#212529',
        },
        subtitle1: {
            fontSize: '1rem',
            fontWeight: 400,
            color: '#6c757d',
        },
        body1: {
            fontSize: '0.875rem',
            lineHeight: 1.5,
        },
        button: {
            textTransform: 'none', // Sin mayúsculas como Bootstrap
            fontWeight: 400,
            fontSize: '0.875rem',
        },
    },
    shape: {
        borderRadius: 0.375, // 6px - radio de Bootstrap
    },
    shadows: [
        'none',
        '0 0.125rem 0.25rem rgba(0, 0, 0, 0.075)', // Bootstrap shadow-sm
        '0 0.5rem 1rem rgba(0, 0, 0, 0.15)',       // Bootstrap shadow
        '0 1rem 3rem rgba(0, 0, 0, 0.175)',        // Bootstrap shadow-lg
        ...Array(21).fill('none')
    ],
    components: {
        // 🔵 AppBar (Navbar) - Réplica del navbar azul de .NET
        MuiAppBar: {
            styleOverrides: {
                root: {
                    backgroundColor: '#1e4a7b',
                    boxShadow: '0 0.125rem 0.25rem rgba(0, 0, 0, 0.075)',
                    borderBottom: '1px solid rgba(255, 255, 255, 0.1)',
                },
            },
        },

        // 🟦 Botones - Estilo Bootstrap
        MuiButton: {
            styleOverrides: {
                root: {
                    borderRadius: '0.375rem',
                    padding: '0.375rem 0.75rem',
                    fontSize: '0.875rem',
                    lineHeight: 1.5,
                },
                containedPrimary: {
                    backgroundColor: '#1e4a7b',
                    borderColor: '#1e4a7b',
                    '&:hover': {
                        backgroundColor: '#0d2c52',
                        borderColor: '#0d2c52',
                    },
                },
                containedSuccess: {
                    backgroundColor: '#198754',
                    borderColor: '#198754',
                    '&:hover': {
                        backgroundColor: '#0f5132',
                        borderColor: '#0f5132',
                    },
                },
                outlined: {
                    border: '1px solid #dee2e6',
                    '&:hover': {
                        backgroundColor: '#f8f9fa',
                    },
                },
            },
        },

        // 📄 Paper/Cards - Estilo Bootstrap cards
        MuiPaper: {
            styleOverrides: {
                root: {
                    border: '1px solid rgba(0, 0, 0, 0.125)',
                    borderRadius: '0.375rem',
                    boxShadow: '0 0.125rem 0.25rem rgba(0, 0, 0, 0.075)',
                },
                elevation1: {
                    boxShadow: '0 0.125rem 0.25rem rgba(0, 0, 0, 0.075)',
                },
            },
        },

        // 🏷️ Cards específicas
        MuiCard: {
            styleOverrides: {
                root: {
                    border: '1px solid rgba(0, 0, 0, 0.125)',
                    borderRadius: '0.375rem',
                },
            },
        },

        // 📊 Tablas - Estilo Bootstrap table-striped
        MuiTable: {
            styleOverrides: {
                root: {
                    borderCollapse: 'separate',
                    borderSpacing: 0,
                },
            },
        },
        MuiTableHead: {
            styleOverrides: {
                root: {
                    backgroundColor: '#f8f9fa',
                    '& .MuiTableCell-head': {
                        fontWeight: 600,
                        color: '#495057',
                        borderBottom: '2px solid #dee2e6',
                    },
                },
            },
        },
        MuiTableRow: {
            styleOverrides: {
                root: {
                    '&:nth-of-type(even)': {
                        backgroundColor: 'rgba(0, 0, 0, 0.02)', // striped rows
                    },
                    '&:hover': {
                        backgroundColor: 'rgba(0, 0, 0, 0.04)',
                    },
                },
            },
        },
        MuiTableCell: {
            styleOverrides: {
                root: {
                    borderBottom: '1px solid #dee2e6',
                    padding: '0.75rem',
                    verticalAlign: 'top',
                },
            },
        },

        // 📌 Inputs/Formularios - Estilo Bootstrap
        MuiTextField: {
            styleOverrides: {
                root: {
                    '& .MuiOutlinedInput-root': {
                        '& fieldset': {
                            borderColor: '#ced4da',
                            borderRadius: '0.375rem',
                        },
                        '&:hover fieldset': {
                            borderColor: '#adb5bd',
                        },
                        '&.Mui-focused fieldset': {
                            borderColor: '#1e4a7b',
                            borderWidth: '1px',
                        },
                    },
                },
            },
        },

        // 🚪 Drawer/Sidebar - Réplica del sidebar de .NET
        MuiDrawer: {
            styleOverrides: {
                paper: {
                    backgroundColor: '#343a40', // Bootstrap dark
                    color: 'rgba(255, 255, 255, 0.8)',
                    borderRight: '1px solid rgba(255, 255, 255, 0.1)',
                },
            },
        },

        // 📍 List items del sidebar
        MuiListItemButton: {
            styleOverrides: {
                root: {
                    '&:hover': {
                        backgroundColor: 'rgba(255, 255, 255, 0.1)',
                    },
                    '&.Mui-selected': {
                        backgroundColor: '#1e4a7b',
                        '&:hover': {
                            backgroundColor: '#0d2c52',
                        },
                    },
                },
            },
        },

        // 🏷️ Chips/Badges - Estilo Bootstrap badges
        MuiChip: {
            styleOverrides: {
                root: {
                    borderRadius: '0.375rem',
                    fontWeight: 400,
                },
                colorSuccess: {
                    backgroundColor: '#d1e7dd',
                    color: '#0f5132',
                },
                colorWarning: {
                    backgroundColor: '#fff3cd',
                    color: '#664d03',
                },
                colorError: {
                    backgroundColor: '#f8d7da',
                    color: '#842029',
                },
            },
        },
    },
});

export default goldBusinessTheme;