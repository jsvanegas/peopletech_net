var __app = {

	detenerEvento:function(e){
		if (e.preventDefault) {
			e.preventDefault();
		}
		if (e.stopPropagation) {
			e.stopPropagation();
		}
		if (e.returnValue!==undefined) {
			e.returnValue = false;
		}
	},

	cargarVistaAjax:function(url, success){
		$.get('vistas/'+url, success).fail(function(){
			console.error('Error al cargar la pagina');
		});
	},

	ajax:function(url, params, callback){
		$.ajax({
			url:url,
			type:'POST',
			dataType:'json',
			data:params,
			error:__app.controlarErrorAjax,
			beforeSend:__dom.mostrarCargador,
			success:function(data){
				__dom.ocultarCargador();
				//valida la respuesta
				callback(data);
			}
		});
	},

	controlarErrorAjax:function(err){
		__dom.ocultarCargador();
		console.error(err);
	}


};