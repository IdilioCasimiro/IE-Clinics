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
        url: "/marcacoes/obtermarcacoes",
        success: function (data) {
            $.each(data, function (i, v) {
                events.push({
                    title: v.TipoMarcacao,
                    description: v.Medico,
                    especialidade: v.Especialidade,
                    start: v.Data,
                    end: v.Data,
                    details: v.Medico,
                    paciente: v.Paciente,
                    obs: v.Observacao,
                    backgroundColor: v.TipoMarcacao == 'Consulta' ? '#F3565D' : ''
                });
            })
            GenerateCalendar(events, '#calendario');
        },
        error: function (error) {
            alert(error.responseText);
        }
    })

    function GenerateCalendar(events, calendarName) {
        $(calendarName).fullCalendar('destroy');
        $(calendarName).fullCalendar({
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
                $('#especialidade').text(callEvent.especialidade);
                var mes = new Date(callEvent.start).getMonth() + 1;
                $('#data').text(
                    new Date(callEvent.start).getDate()
                    + "/" + mes
                    + "/" + new Date(callEvent.start).getFullYear());
                $('#hora').text(new Date(callEvent.start).getHours()
                    + "h:" + new Date(callEvent.start).getMinutes());
                $('#medico').text(callEvent.details);
                $('#obs').text(callEvent.obs);
            }
        })
    }
});