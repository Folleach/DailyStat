import React from 'react';
import { useParams } from 'react-router-dom';
import { getAll, setThing } from '../DailyStatClient';
import { useEffect, useState } from 'react';
import ThingInput from '../Components/ThingInput';

function getItem(current, statId, value, setCurrent) {
    const name = value.name;
    const color = current == value.id ? '#3090DA': '#EEE';
    return <div
        key={name}
        onClick={() => setThing(statId, name).then(value => setCurrent(value.selected))}
        style={{margin: "8px 0px 0px 0px", background: color, height: "30px", userSelect: 'none', display: 'flex', alignItems: 'center'}}>
        <p>{name}</p>
    </div>
}

export default function ThingsPage() {
    const [things, setThings] = useState([]);
    const [currentThing, setCurrentThing] = useState('');
    const params = useParams();
    const statId = params.statId;

    useEffect(() => {
        console.log('update things...');
        getAll(statId).then(response => {
            setThings(response);
        });
    }, []);

    useEffect(() => {
        console.log('update things after select...');
        getAll(statId).then(response => {
            setThings(response);
        });
    }, [currentThing]);

    return <div style={{margin: "18px"}}>
        <h1>Things...</h1>
        {things.map(value => getItem(currentThing, statId, value, setCurrentThing))}
        <div>
            <ThingInput select={v => setThing(statId, v).then(value => setCurrentThing(value.selected))} />
        </div>
    </div>
}
