# TestTaskOCS
Test-Task 
## Description of the task:
создание заявки - /api/meetings

редактирование заявки - /api/meetings/{ID}

удаление заявки - /api/meetings/{ID}

получение заявок поданных после указанной даты - /api/meetingDate/{ID} - используйте такой формат даты (year-month-date hour:minutes:seconds.269+03)

получение заявок не поданных и старше определенной даты - /api/unsubmitedDate/{ID}

получение текущей не поданной заявки для указанного пользователя - /api/unsubmited/{ID}

получение заявки по идентификатору - /api/meetings/{ID}

получение списка возможных типов активности - /api/meetingTopic/{ID}
