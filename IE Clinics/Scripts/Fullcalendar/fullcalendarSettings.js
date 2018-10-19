$(document).ready(function () {

    var getUrlParameter = function getUrlParameter(sParam) {
        var sPageURL = decodeURIComponent(window.location.search.substring(1)),
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;

        for (i = 0; i < sURLVariables.length; i++) {
            sParameterName = sURLVariables[i].split('=');

            if (sParameterName[0] === sParam) {
                return sParameterName[1] === undefined ? true : sParameterName[1];
            }
        }
    };

    var events = [];

    $.ajax({
        type: "GET",
        url: "/marcacao/obtermarcacoes",
        success: function (data) {
            $.each(data, function (i, v) {
                events.push({
                    title: v.TipoMarcacao,
                    description: v.Especialidade,
                    start: v.Data,
                    end: v.Data,
                    details: v.Medico,
                    paciente: v.Paciente,
                    obs: v.Observacao,
                    backgroundColor: v.TipoMarcacao == 'Consulta' ? '#F3565D' : ''
                });
            })
            GenerateCalendar(events);
        },
        error: function (error) {
            alert(error.responseText);
        }
    })

    $.ajax({
        type: "GET",
        url: "/marcacao/obtermarcacoesmedico/2" + getUrlParameter('nome'),
        success: function (data) {
            $.each(data, function (i, v) {
                events.push({
                    title: v.TipoMarcacao,
                    description: v.Especialidade,
                    start: v.Data,
                    end: v.Data,
                    details: v.Medico,
                    paciente: v.Paciente,
                    obs: v.Observacao,
                    backgroundColor: v.TipoMarcacao == 'Consulta' ? '#F3565D' : ''
                });
            })
            GenerateCalendar(events);
        },
        error: function (error) {
            alert(error.responseText);
        }
    })

    function GenerateCalendar(events) {
        $('#calendario').fullCalendar('destroy');
        $('#calendario').fullCalendar({
            contentHeight: 400,
            dafaultDate: new Date(),
            timeFormat: 'h(:mm)a',
            header: {
                left: "title",
                center: "",
                right: "prev,next,today,month,agendaWeek,agendaDay"
            },
            eventLimit: true,
            events: events,
            eventClick: function (callEvent) {
                $('#modal').modal();
                $('#paciente').text(callEvent.paciente);
                $('#tipoMarcacao').text(callEvent.title);
                $('#especialidade').text(callEvent.description);
                var mes = new Date(callEvent.start).getMonth() + 1;
                $('#data').text(
                    new Date(callEvent.start).getDate()
                    + "/" + mes
                    + "/" + new Date(callEvent.start).getFullYear());
                var hora = new Date(callEvent.start).getHours() - 1;
                $('#hora').text(hora
                    + ":" + new Date(callEvent.start).getMinutes());
                $('#medico').text(callEvent.details);
                $('#obs').text(callEvent.obs);
            }
        })
    }
});