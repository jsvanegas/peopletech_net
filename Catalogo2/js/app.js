String.prototype.toNumber = function (moneda, decimales) {
    if (isNaN(this)) {
        return '-';
    }

    var signo = (moneda) ? moneda : '';
    var decimas = (decimales !== undefined && !isNaN(decimales)) ? decimales : 2;

    strVal = '';
    if (this.toString().indexOf('.') !== -1) {
        strVal = parseFloat(this.toString().substring(0, this.toString().lastIndexOf('.') + 3));
    } else {
        strVal = parseFloat(this);
    }
    var resultado = '';
    var valornegativo = strVal < 0;
    strVal = Math.abs(strVal);
    if (decimas < 1) { //se pregunta menor que uno, para evitar una excepción no controlada por números negativos
        resultado += parseFloat(strVal).toFixed(1);
        resultado = resultado.replace(/\d(?=(\d{3})+\.)/g, '$&,');
        resultado = resultado.substring(0, resultado.lastIndexOf('.'));
        resultado = valornegativo ? '-' + resultado : resultado;
        return resultado;
    }

    resultado += parseFloat(strVal).toFixed(decimas);
    resultado = resultado.replace(/\d(?=(\d{3})+\.)/g, '$&,');
    resultado = valornegativo ? '-' + resultado : resultado;
    return (signo === '%') ? resultado + signo : signo + resultado;
};


Handlebars.registerHelper('moneda', function (valor, signo) {
    return valor && valor !== 0 ? valor.toString().toNumber((signo ? signo : '$'), 2) : ' - ';
});

(function () {

    var categoriaModelo = {

        categorias: [],

    };

    var categoriaControl = {

        ajax: function (url, data, success) {
            $.ajax({
                url: 'handlers/' + url,
                data: data,
                type: 'POST',
                dataType: 'json',
                success: function (data) {
                    if (data.Codigo === -1) {
                        //mostrar alerta de error
                        return;
                    }
                    success(data);
                },
                error: categoriaControl.onError
            });
        },

        consultarCategorias: function () {
            categoriaControl.ajax('CategoriasHandler.ashx', { accion: 'consultar' }, categoriaControl.crearLista);
        },

        consultarProductos: function () {
            categoriaControl.ajax('ProductosHandler.ashx', { accion: 'consultar' }, categoriaControl.crearListaProductos);
        },

        onError: function (err) {
            console.error(err);
        },
        
        crearLista: function (respuesta) {
            var divCategorias = $('#divCategorias').empty();
            if (respuesta.Codigo === 0) {
                categoriaModelo.categorias = [];
                divCategorias.html('<p class="text-center">No se encontraron resultados</p>');
                return;
            }
            var categorias = categoriaModelo.categorias = respuesta.Datos;
            categorias.push({
                IdCategoria: 0,
                NombreCategoria: 'Todas las Categorias',
                ColorFondo: '#DEDEDE',
                ColorFuente: '#666'
            });
            var tplCategorias = $('#tplCategorias').html();
            var fxTemplate = Handlebars.compile(tplCategorias);
            divCategorias.append(fxTemplate({ categorias: categorias }));
            divCategorias.find('a[data-id]').on('click', categoriaControl.filtrarProductos);
        },

        crearListaProductos: function (respuesta) {
            var divProductos = $('#divProductos').empty();
            if (respuesta.Codigo === 0) {
                divProductos.html('<p class="text-center">No se encontraron productos</p>');
                return;
            }
            var productos = respuesta.Datos;
            for (var i = 0; i < productos.length; i++) {
                var categoria = categoriaControl.obtenerCategoriaPorId(productos[i].IdCategoria);
                productos[i].NombreCategoria = (categoria) ? categoria : 'Sin Categoria';
            }
            divProductos.append(Handlebars.compile($('#tplProductos').html())({ productos: productos }));
        },

        obtenerCategoriaPorId: function (idCategoria) {
            for (var i = 0; i < categoriaModelo.categorias.length; i++) {
                var categoria = categoriaModelo.categorias[i];
                if (categoria.IdCategoria === idCategoria) {
                    return categoria.NombreCategoria;
                }
            }
            return false;
        },

        filtrarProductos: function (e) {
            e.preventDefault();
            var link = $(this);
            var idCategoria = (link.attr('data-id') === '0') ? undefined : link.attr('data-id');
            categoriaControl.ajax(
                'ProductosHandler.ashx',
                { accion: 'consultar', idCategoria: idCategoria  },
                categoriaControl.crearListaProductos
            );
        },

        buscarProductos: function () {
            var txt = $(this);
            var valor = txt.val().trim();
            if (valor.length === 0) {
                categoriaControl.consultarProductos();
                return;
            }

            if (valor.length >= 3) {
                categoriaControl.ajax(
                    'ProductosHandler.ashx',
                    { accion: 'consultar', nombre:valor },
                    categoriaControl.crearListaProductos
                );
            }

        }

    };

    categoriaControl.consultarCategorias();
    categoriaControl.consultarProductos();

    $('#txtBuscar').on('keyup', categoriaControl.buscarProductos);

})();