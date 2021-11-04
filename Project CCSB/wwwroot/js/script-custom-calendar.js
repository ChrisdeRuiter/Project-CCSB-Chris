﻿var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    $("#appointmentDate").kendoDateTimePicker({
        value: new Date(),
        dateInput: false,
        format: "d-M-yyyy H:mm:ss",
        timeFormat: "HH:mm"
    });
    InitializeCalendar();
});
var kalender;
function InitializeCalendar() {
    try {
        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {
            kalender = new FullCalendar.Calendar(calendarEl, {
                locale: 'nl',
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                selectable: true,
                weekNumbers: true,
                editable: false,
                select: function (event) {
                    onShowModal(event, null);
                },
                evenDisplay: 'block',
                events: function (fethinfo, succesCallback, failureCallback) {
                    $.ajax({
                        url: routeURL + '/api/AppointmentApi/GetCalenderData?appointmentId' + $("appointmentId").val(),
                        type: 'GET',
                        dataType: 'json',
                        success: function (response) {
                            var events = [];
                            if (response.status === 1) {
                                $.each(response.dataenum, function (i, data) {
                                    events.push({
                                        title: data.title,
                                        description: data.description,
                                        start: data.startDate,
                                        end: data.endDate,
                                        backgroundColor: data.isAdminApproved ? "#28a745" : "#dc3545",
                                        textColor: "white",
                                        id: data.id
                                    });
                                })
                            }
                            succesCallback(events);
                        },
                        error: function (xhr) {
                            $.notify("Emre", "emre");
                        }
                    });
                }
            });
            kalender.render();
        }
    }
    catch (e) {
        alert(e);
    }
}

function onShowModal(obj, isEventDeail) {
    $("#appointmentInput").modal("show");
}

function onCloseModal() {
    $("#appointmentInput").modal("hide");
}


function onSubmitForm() {
    if (!checkValidation()) return;
    var requestData = {
        AppointmentId: parseInt($("id").val()),
        TimeAndMoment: $("#appointmentDate").val(),
        Action: $("#action").val()
    };

    $.ajax({
        url: routeURL + "api/AppointmentApi/SaveCalendarData",
        type: "POST",
        data: JSON.stringify(requestData),
        contentType: "application/json",
        succes: function (response) {
            if (response.status === 1 || response.status === 2) {
                $.notify(response.message, "succes");
                onCloseModal();
            } else {
                $.notify(response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error", "Foutje");
        }
    });
}