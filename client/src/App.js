import { Routes, Route } from 'react-router-dom'
import './App.css';
import ThingsPage from './Pages/ThingsPage';

function App() {
  return <Routes>
    <Route path='things/:statId' element={<ThingsPage />} />
  </Routes>;
}

export default App;
