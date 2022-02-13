const apiUrl = "https://folleach.ru/dailyStat/api"

async function doPost(url, data) {
    return await fetch(url, {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        method: "POST",
        body: JSON.stringify(data)
    });
}

export async function getAll(statId) {
    const response = await fetch(`${apiUrl}/thing/${statId}`);
    return await response.json();
}

export async function setThing(statId, name) {
    const response = await doPost(`${apiUrl}/thing/${statId}`, {
        thingName: name
    });
    return await response.json();
}
