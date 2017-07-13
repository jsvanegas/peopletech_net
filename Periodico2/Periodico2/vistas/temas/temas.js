(function(){

	//compilar el template al inicio de la pagina.
    var tplFilaTema = Handlebars.compile($('#tplFilaTema').html());

    __dom.divAplicacion.find('#linkNuevoTema').on('click', mostrarModalTema);
    __dom.divAplicacion.find('.iconos-temas a').on('click', seleccionarIcono);


    //invoca por medio de ajax la lista de temas
	function cargarTemas() {
	    __app.ajax('/temas/todos', null, onCargarTemasCompleto);
	}

    function onCargarTemasCompleto(data) {
    	var tbody = $('#tblTemas tbody').empty();
    	tbody.append(tplFilaTema({temas:data.Datos}));
    }

    function mostrarModalTema(event){
        __app.detenerEvento(event);
        var btnAceptar = {text:'Guardar Tema', click:guardarTema};
        var btnCancelar = {text:'Cancelar', click:cancelarDialogoTema};
    	__dom.abrirModal('Agregar Nuevo Tema', $('#nuevo_tema'),  btnAceptar, btnCancelar);
    }

    function seleccionarIcono(event) {
        __app.detenerEvento(event);
        var link = $(this);
        var iconosTemas = link.parent();
        iconosTemas.find('a.btn-primary').removeClass('btn-primary').addClass('btn-default');
        link.addClass('btn-primary').removeClass('btn-default');
    }

    function guardarTema() {
        var data = {
            tema:$('#nuevo_tema').find('#txtTema').val(),
            icono: $('#nuevo_tema .iconos-temas a.btn-primary i').attr('class')
        };
        __app.ajax('/temas/registrar', data, onGuardarTemaCompleto);
    }

    function onGuardarTemaCompleto(data) {
        __dom.cerrarModal();
        cargarTemas();
    }

    function cancelarDialogoTema() {
        __dom.cerrarModal();
    }

    cargarTemas();
})();