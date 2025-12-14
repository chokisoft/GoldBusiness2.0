// responsive.js - manejo de responsive para Blazor
window.setupResponsiveLayout = (dotNetHelper) => {

    // Función para manejar el cambio de tamaño
    const handleResize = () => {
        if (dotNetHelper) {
            try {
                dotNetHelper.invokeMethodAsync('HandleResize', window.innerWidth);
            } catch (e) {
                console.error('Error notificando resize:', e);
            }
        }
    };

    // Agregar event listener para resize
    window.addEventListener('resize', handleResize);

    // Llamar inicialmente
    setTimeout(handleResize, 100);

    // Inicializar componentes Bootstrap si están disponibles
    if (typeof bootstrap !== 'undefined') {
        // Tooltips
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
        tooltipTriggerList.forEach(function (tooltipTriggerEl) {
            try {
                new bootstrap.Tooltip(tooltipTriggerEl);
            } catch (e) {
                console.error('Error inicializando tooltip:', e);
            }
        });
    }

    // Retornar función para limpiar
    return {
        dispose: function () {
            window.removeEventListener('resize', handleResize);
        }
    };
};