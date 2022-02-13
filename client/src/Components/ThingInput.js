import { useState } from "react";

export default function ThingInput({ select }) {
    const [text, setText] = useState('');
    console.log(`text is: '${text}'`);
    return <div>
        <input onChange={(e) => setText(e.target.value)} value={text} />
        <button onClick={() => select(text)}>Select</button>
    </div>
}
