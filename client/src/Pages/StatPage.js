import react from "react";
import { useParams } from "react-router-dom";
import Timeline from "../Components/Timeline";

export default function StatPage() {
    const params = useParams();
    const statId = params.statId;
    return <div>
        <h1>Statistics</h1>
        <Timeline />
    </div>
}
