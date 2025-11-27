import React from 'react';
import { useNavigate } from 'react-router-dom';

function RoleSelectionPage()
{
    const navigate = useNavigate();
    
    const handleTeamLeadClick = () => {
        navigate('/team-lead')  // Переход на экран руководителя
    }
    
    const handleTeamMemberClick = () => {
        navigate('/team-member') // Переход на экран участника
    }
    
    return (
      <div style={{
          backgroundColor: '#EFECE3',
          height: '100vh',
          overflow: 'hidden',
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
          justifyContent: 'center',
          gap: '80px',
          padding: '20px',
          boxSizing: 'border-box'
      }}>
          <button 
              onClick={handleTeamLeadClick}
              style={{
                  backgroundColor: '#8FABD4',
                  width: '800px',
                  height: '120px',
                  border: '4px solid #4A70A9',
                  borderRadius: '8px',
                  fontSize: '64px',
              }}>
              Руководитель команды
          </button>
          <button
              onClick={handleTeamMemberClick}
              style={{ 
                  backgroundColor: '#8FABD4',
                  width: '800px',
                  height: '120px',
                  border: '4px solid #4A70A9',
                  borderRadius: '8px',
                  fontSize: '64px',
              }}>
              Участник команды
          </button>
      </div>
    );
}

export default RoleSelectionPage;