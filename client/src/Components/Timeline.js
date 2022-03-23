import react from "react";

export default function Timeline() {
    return <div>
        <p>12.01.2022</p>
        <div style={{background: "#EEE", display: "flex"}}>
            <div title="Сон" style={{height: "10px", background: "red", width: "10%"}} />
            <div title="Работа" style={{height: "10px", background: "green", width: "100%"}} />
            <div title="Работа" style={{height: "10px", background: "blue", width: "100%"}} />
        </div>
    </div>
}
