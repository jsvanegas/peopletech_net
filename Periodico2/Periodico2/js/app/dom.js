var __dom = {

    divAplicacion : $('#aplicacion'),
    divModal: $('#modal'),

    configurarEventosModal: function () {
        __dom.divModal.on('hide.bs.modal', function () {
            var contenedor = __dom.divModal.attr('data-contenedor');
            if (contenedor !== 'none') {
                __dom.divAplicacion.find('#' + contenedor)
                    .append(__dom.divModal.find('.modal-body *:first').hide()
                );
            }
        });
    },

	abrirVista:function(evento){
		__app.detenerEvento(evento);
		var link = $(this);
		__app.cargarVistaAjax(link.attr('href'), __dom.onAbrirVistaCompleto);
	},

	onAbrirVistaCompleto:function(vista){
		$('div#aplicacion').empty().append(vista);
	},

	mostrarCargador:function(){
		$('#cortina').fadeIn('fast');
		$('body').addClass('no-scroll');
	},

	ocultarCargador:function(){
		$('#cortina').fadeOut('fast');
		$('body').removeClass('no-scroll');	
	},

	abrirModal:function(titulo, contenido, btnAceptar, btnCancelar){
	    __dom.divModal.find('.modal-title').text(titulo);

		if (typeof contenido === 'string') {
		    __dom.divModal.attr('data-contenedor', 'none');
		    __dom.divModal.find('.modal-body').empty().text(contenido);
		} else {
		    __dom.divModal.attr('data-contenedor', contenido.parent().attr('id'));
		    __dom.divModal.find('.modal-body').empty().append(contenido.show());
		}




		var modalFooter = __dom.divModal.find('.modal-footer').empty();
		if (btnAceptar) {
		    var btn = $('<button class="btn btn-primary">')
                            .text(btnAceptar.text)
                            .on('click', btnAceptar.click);
		    modalFooter.append(btn);
		}
		if (btnCancelar) {
		    var btnC = $('<button class="btn btn-danger">')
                            .text(btnCancelar.text)
                            .on('click', btnCancelar.click);
		    modalFooter.append(btnC);
		}
		__dom.divModal.modal('show');
	},

	cerrarModal: function () {
	    __dom.divModal.modal('hide');
	}
};

__dom.configurarEventosModal();