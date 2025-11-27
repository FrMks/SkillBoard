import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import RoleSelectionPage from './pages/RoleSelectionPage'
import TeamLeadPage from './pages/TeamMemberPage'
import TeamMemberPage from './pages/TeamMemberPage'
import logo from './logo.svg';
import './App.css';

function App() {
  return (
      <BrowserRouter>
          <Routes>
              <Route path="/" element={<RoleSelectionPage />} />
              <Route path="/team-lead" element={<TeamLeadPage />} />
              <Route path="/team-member" element={<TeamMemberPage />} />
          </Routes>
      </BrowserRouter>
  );
}

export default App;
