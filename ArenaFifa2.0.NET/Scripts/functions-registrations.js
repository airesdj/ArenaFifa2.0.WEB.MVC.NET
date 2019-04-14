function includeFileScreenModalCoaches(pID) {
	$("#includedContentQuestionDelete").load("menu-moderator-question-modal.html", function() {
		$("#modalScreeenDeleteTitle").html( "CADASTRO DE TÉCNICOS" );
		$("#modalScreeenDeleteSubTitle").html( "Inativação" );
		$("#modalScreeenDeleteQuestion").html ( "Deseja realmente inativar o técnico selecionado (#ID: "+pID+")?" );
		$("#modalScreeenDeleteButton").on("click", function(){ $('#bs-result-modal-sm').modal('show'); });
	}); 
	$("#includedContentResultMessage").load("menu-moderator-result-modal.html", function() {
		$("#modalScreeenResultTitle").html( "CADASTRO DE TÉCNICOS" );
		$("#modalScreeenResultSubTitle").html( "Inativação" );
		$("#modalScreeenResultMessage").html ( "O técnico (#ID: "+pID+") foi inativado com sucesso." );
	}); 
}

function includeFileScreenResultAction(pTitle) {
	$("#includedContentResultMessage").load("menu-moderator-result-modal.html", function() {
		$("#modalScreeenResultTitle").html( pTitle );
		$("#modalScreeenResultSubTitle").html( "" );
		$("#modalScreeenResultMessage").html ( "" );
	});
}

function includeFileScreenModal(pTitle, pID) {
	$("#includedContentQuestionDelete").load("menu-moderator-question-modal.html", function() {
		$("#modalScreeenDeleteTitle").html( "CADASTRO DE "+pTitle );
		$("#modalScreeenDeleteSubTitle").html( "Exclusão" );
		$("#modalScreeenDeleteQuestion").html ( "Deseja realmente excluir o item selecionado (#ID: "+pID+")?" );
		$("#modalScreeenDeleteButton").on("click", function(){ $('#bs-result-modal-sm').modal('show'); });
	}); 
	$("#includedContentResultMessage").load("menu-moderator-result-modal.html", function() {
		$("#modalScreeenResultTitle").html( "CADASTRO DE "+pTitle );
		$("#modalScreeenResultSubTitle").html( "Exclusão" );
		$("#modalScreeenResultMessage").html ( "O item (#ID: "+pID+") foi excluído com sucesso." );
	}); 
}

function includeFileScreenModalGeneral(pTitle, pSubTitle, pQuestionMsg) {
	$("#includedContentMessageGeneral").load("menu-moderator-question-modal-2.html", function() {
		$("#modalScreeenMsgTitle").html( "CADASTRO DE "+pTitle );
		$("#modalScreeenMsgSubTitle").html( pSubTitle );
		$("#modalScreeenMsgQuestion").html ( pQuestionMsg );
		$("#modalScreeenMsgButton").on("click", function(){ alert("Running process to upgrade the team squad..."); });
	}); 
}
function includeFileScreenModalGeneralViewIntelegence(pHtmlFile, pTitle) {
	$("#includedContentViewSendEmail").load(pHtmlFile, function() {
		$("#modalScreeenMsgTitle").html( "CADASTRO DE "+pTitle );
		//$("#modalScreeenMsgButton").on("click", function(){ alert("Running process to send the invite email to the next season..."); });
		$("#includedContentChampionshipShortDetails").load("menu-moderator-championship-short-details.html"); 
	}); 
}
function activateRegistrationForm(pNewPageRedirect) {
	window.Parsley.on('field:error', function() {
		var ok = $('.gentelella-parsley-error').length === 0;
		$('.bs-callout-warning').toggleClass('gentelella-hidden', ok);
	})
	  .on('form:submit', function() {
		  //codigo
		  window.location.href = pNewPageRedirect;
	  });

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
