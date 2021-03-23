
var ObjetoAlerta = new Object();

ObjetoAlerta.AlertarTela = function(tipo, mensagem){
    $("#AlertaJavaScript").html("");
    
    var classeTipoAlerta = "";
    
    if(tipo == 1){
        classeTipoAlerta = "alert alert-success";
    }
    else if(tipo == 2){
        classeTipoAlerta = "alert alert-danger";
    }
    
    var divAlert = $("<div>", {class: classeTipoAlerta});

    divAlert.append('<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>');
    divAlert.append('<strong>' + mensagem + '</strong>');

    $("#AlertaJavaScript").html(divAlert);

    window.setTimeout(function () {
        $(".alert").fadeTo(1500, 0).slideUp(500, function () {
            $(this).remove();
        });
    }, 5000);
    
}
