function includeFileScreenModalCoaches(actionName, actionForm) {
	$("#modalScreeenDeleteTitle").html( "CADASTRO DE TÉCNICOS" );
	$("#modalScreeenDeleteSubTitle").html( "Inativação" );
    $("#modalScreeenDeleteButton").on("click", function () { submeteModerator(actionName, actionForm, ''); });
}

function includeFileScreenResultAction(pTitle) {
	$("#includedContentResultMessage").load("menu-moderator-result-modal.html", function() {
		$("#modalScreeenResultTitle").html( pTitle );
		$("#modalScreeenResultSubTitle").html( "" );
		$("#modalScreeenResultMessage").html ( "" );
	});
}

function includeFileScreenModalDelete(pTitle, actionName, actionForm) {
	$("#modalScreeenDeleteTitle").html( "CADASTRO DE "+pTitle );
	$("#modalScreeenDeleteSubTitle").html( "Exclusão" );
    $("#modalScreeenDeleteButton").on("click", function () { submeteModerator(actionName, actionForm, ''); });

    $("#modalScreeenResultTitle").html("CADASTRO DE " + pTitle);
	$("#modalScreeenResultSubTitle").html( "Exclusão" );
}

function changeQuestionDescriptionInativate(pID) {
    $('#selectedID').val(pID);
    $("#modalScreeenDeleteQuestion").html("Deseja realmente inativar o técnico selecionado (#ID: " + pID + ")?");
}

function changeQuestionDescriptionDelete(pID) {
    $('#selectedID').val(pID);
    $("#modalScreeenDeleteQuestion").html("Deseja realmente excluir o item selecionado (#ID: " + pID + ")?");
}

function includeFileScreenModalGeneral(pTitle, pSubTitle, pQuestionMsg, actionName, actionForm) {
	$("#modalScreeenMsgTitle").html( "CADASTRO DE "+pTitle );
    $("#modalScreeenMsgSubTitle").html(pSubTitle);
    $("#modalScreeenMsgQuestion").html(pQuestionMsg);
    $("#modalScreeenMsgButton").on("click", function () { submeteModerator(actionName, actionForm, ''); });
}
function changeQuestionDescriptionGeneral(pID) {
    var strQuestion = $("#modalScreeenMsgQuestion").html();
    $('#selectedID').val(pID);
    $("#modalScreeenMsgQuestion").html(strQuestion.replace("<selectid>", pID));
}

function includeFileScreenModalGeneralViewIntelegence(pHtmlFile, pTitle) {
	$("#includedContentViewSendEmail").load(pHtmlFile, function() {
		$("#modalScreeenMsgTitle").html( "CADASTRO DE "+pTitle );
		//$("#modalScreeenMsgButton").on("click", function(){ alert("Running process to send the invite email to the next season..."); });
		$("#includedContentChampionshipShortDetails").load("menu-moderator-championship-short-details.html"); 
	}); 
}
function activateRegistrationForm(pNewPageRedirect, actionForm) {
	window.Parsley.on('field:error', function() {
		var ok = $('.gentelella-parsley-error').length === 0;
		$('.bs-callout-warning').toggleClass('gentelella-hidden', ok);
    })
    if (pNewPageRedirect == "BenchDetails") {

        $("#rdoTipoH2H").change(function () {
            if (this.checked) {
                $("#txtTime").prop('required', false).val('');
            }
        })

        $("#rdoTipoFUT").change(function () {
            if (this.checked) {
                $("#txtTime").attr("required", "true");
            }
        })

        $("#rdoTipoPRO").change(function () {
            if (this.checked) {
                $("#txtTime").attr("required", "true");
            }
        })

        .on('form:success', function () {
            return true; // Don't submit form for this demo
        });
    }
    else if (pNewPageRedirect == "UserDetails") {

        $("#cmbHeardUs").on("change", function () {
            if ($(this).val() == "OUTROS") {
                $("#whatkindofmedia").removeClass("disabled").removeAttr("disabled").focus();
                $("#whatkindofmedia").attr("required", "true");
            }
            else {
                $("#whatkindofmedia").val("");
                $("#whatkindofmedia").addClass("disabled").attr("disabled", "true");
                $("#whatkindofmedia").prop('required', false).val('');
            }
        });

        if ($("#cmbHeardUs").val() == "OUTROS") {
            $("#whatkindofmedia").removeClass("disabled").removeAttr("disabled").focus();
            $("#whatkindofmedia").attr("required", "true");
        }
        else {
            $("#whatkindofmedia").val("");
            $("#whatkindofmedia").addClass("disabled").attr("disabled", "true");
            $("#whatkindofmedia").prop('required', false).val('');
        }

    }

    if (actionForm == "VIEW") {
        $("input[type!='button']").attr('disabled', 'true');
        $("select").attr('disabled', 'true');
    }

    window.Parsley.addValidator('datevalid', {
	  validateString: function(value) {
		value = value.replace("_", "");
		if (value.length<10) { return false; }
		else { return moment(value, "DD/MM/YYYY").isValid(); }
	  },
	  messages: {
		en: 'O campo é inválido.',
		fr: ""
	  }
	});
}
function submeteModerator(actionName, actionForm, itemSelected) {
    $("#actionForm").val(actionForm);
    if (itemSelected != "") { $("#selectedID").val(itemSelected); }
    if (actionForm == "VOLTAR") {
        $("#comeback-form").attr("action", "/Moderator/" + actionName);
        $("#comeback-form").submit();
    }
    else {
        $("#registration-form").attr("action", "/Moderator/" + actionName);
        $("#registration-form").submit();
    }
}

function setOrderingDatatableResponsive(arrayOrder1, arrayOrder2, arrayOrder3) {
    var table = $('#datatable-responsive').DataTable();
    if (arrayOrder2 != null && arrayOrder3 != null)
        table.order([[arrayOrder1[0], arrayOrder1[1]], [arrayOrder2[0], arrayOrder2[1]], [arrayOrder3[0], arrayOrder3[1]]]);
    else if (arrayOrder3 == null)
        table.order([[arrayOrder1[0], arrayOrder1[1]], [arrayOrder2[0], arrayOrder2[1]]]);
    else
        table.order([[arrayOrder1[0], arrayOrder1[1]]]);
    //table.order([[3, 'desc'], [0, 'asc']]); --> example
    table.draw();
    table = null;
}
