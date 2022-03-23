import { Routes, Route } from 'react-router-dom'
import './App.css';
import StatPage from './Pages/StatPage';
import ThingsPage from './Pages/ThingsPage';

function App() {
  return <div style={{ margin: "18px" }}>
    <Routes>
      <Route path='things/:statId' element={<ThingsPage />} />
      <Route path='stat/:statId' element={<StatPage />} />
    </Routes>
  </div>
}

export default App;
