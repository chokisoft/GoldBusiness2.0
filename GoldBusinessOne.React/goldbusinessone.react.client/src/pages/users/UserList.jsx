import { useState, useEffect } from 'react';
import {
    Box, Paper, Typography, Button,
    TextField, InputAdornment, IconButton
} from '@mui/material';
import {
    Search as SearchIcon,
    Add as AddIcon,
    Edit as EditIcon,
    Delete as DeleteIcon
} from '@mui/icons-material';
import { DataGrid } from '@mui/x-data-grid';
import axiosClient from '../../api/axiosClient';
import { useAuth } from '../../contexts/AuthContext';

const UserList = () => {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [search, setSearch] = useState('');
    const { hasPermission } = useAuth();

    const fetchUsers = async () => {
        try {
            setLoading(true);
            const response = await axiosClient.get('/users');
            setUsers(response.data || []);
        } catch (error) {
            console.error('Error cargando usuarios:', error);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchUsers();
    }, []);

    // Columnas de la tabla
    const columns = [
        { field: 'id', headerName: 'ID', width: 70 },
        { field: 'email', headerName: 'Email', width: 200 },
        { field: 'firstName', headerName: 'Nombre', width: 150 },
        { field: 'lastName', headerName: 'Apellido', width: 150 },
        { field: 'phoneNumber', headerName: 'Teléfono', width: 150 },
        {
            field: 'isActive',
            headerName: 'Estado',
            width: 120,
            renderCell: (params) => (
                <Box
                    sx={{
                        backgroundColor: params.value ? '#4caf50' : '#f44336',
                        color: 'white',
                        padding: '4px 8px',
                        borderRadius: '4px',
                        fontSize: '0.875rem'
                    }}
                >
                    {params.value ? 'Activo' : 'Inactivo'}
                </Box>
            )
        },
        {
            field: 'actions',
            headerName: 'Acciones',
            width: 150,
            renderCell: (params) => (
                <Box>
                    {hasPermission('perm.users.edit') && (
                        <IconButton size="small" color="primary">
                            <EditIcon />
                        </IconButton>
                    )}
                    {hasPermission('perm.users.delete') && (
                        <IconButton size="small" color="error">
                            <DeleteIcon />
                        </IconButton>
                    )}
                </Box>
            ),
        },
    ];

    // Filtrar usuarios por búsqueda
    const filteredUsers = users.filter(user =>
        user.email?.toLowerCase().includes(search.toLowerCase()) ||
        user.firstName?.toLowerCase().includes(search.toLowerCase()) ||
        user.lastName?.toLowerCase().includes(search.toLowerCase())
    );

    return (
        <Box>
            <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 3 }}>
                <Typography variant="h5">
                    Gestión de Usuarios
                </Typography>

                {hasPermission('perm.users.create') && (
                    <Button
                        variant="contained"
                        startIcon={<AddIcon />}
                    >
                        Nuevo Usuario
                    </Button>
                )}
            </Box>

            {/* Barra de búsqueda */}
            <Paper sx={{ p: 2, mb: 3 }}>
                <TextField
                    fullWidth
                    variant="outlined"
                    placeholder="Buscar usuarios..."
                    value={search}
                    onChange={(e) => setSearch(e.target.value)}
                    InputProps={{
                        startAdornment: (
                            <InputAdornment position="start">
                                <SearchIcon />
                            </InputAdornment>
                        ),
                    }}
                />
            </Paper>

            {/* Tabla de usuarios */}
            <Paper sx={{ height: 500, width: '100%' }}>
                <DataGrid
                    rows={filteredUsers}
                    columns={columns}
                    loading={loading}
                    pageSizeOptions={[5, 10, 25]}
                    checkboxSelection={hasPermission('perm.users.select')}
                    disableRowSelectionOnClick
                    sx={{
                        border: 0,
                        '& .MuiDataGrid-cell:focus': {
                            outline: 'none'
                        }
                    }}
                />
            </Paper>

            {/* Estadísticas */}
            <Box sx={{ display: 'flex', gap: 2, mt: 3 }}>
                <Paper sx={{ p: 2, flex: 1, textAlign: 'center' }}>
                    <Typography variant="h6">{users.length}</Typography>
                    <Typography variant="body2" color="text.secondary">
                        Total Usuarios
                    </Typography>
                </Paper>
                <Paper sx={{ p: 2, flex: 1, textAlign: 'center' }}>
                    <Typography variant="h6">
                        {users.filter(u => u.isActive).length}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Usuarios Activos
                    </Typography>
                </Paper>
            </Box>
        </Box>
    );
};

export default UserList;