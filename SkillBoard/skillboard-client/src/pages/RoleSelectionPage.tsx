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
      <div>
          <h1>Выберите роль</h1>
          <div>
              <button onClick={handleTeamLeadClick}>
                  Руководитель команды
              </button>
              <button onClick={handleTeamMemberClick}>
                  Руководитель команды
              </button>
          </div>
      </div>  
    );
}

export default RoleSelectionPage;