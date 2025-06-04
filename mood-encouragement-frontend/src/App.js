import React, { useState, useEffect } from 'react';
import './App.css';

function App() {
  const [moods, setMoods] = useState([]);
  const [selectedMood, setSelectedMood] = useState('');
  const [encouragement, setEncouragement] = useState(null);
  const [dailyEncouragement, setDailyEncouragement] = useState(null);
  const [loading, setLoading] = useState(false);

  const API_BASE_URL = 'http://localhost:5085';

  // Fetch available moods on component mount
  useEffect(() => {
    fetchMoods();
    fetchDailyEncouragement();
  }, []);

  const fetchMoods = async () => {
    try {
      const response = await fetch(`${API_BASE_URL}/moods`);
      const data = await response.json();
      console.log('Fetched moods:', data);
      // Extract mood names from the response objects
      const moodNames = data.map(item => item.Mood || item.mood);
      setMoods(moodNames);
    } catch (error) {
      console.error('Error fetching moods:', error);
    }
  };

  const fetchDailyEncouragement = async () => {
    try {
      const response = await fetch(`${API_BASE_URL}/daily-encouragement`);
      const data = await response.json();
      setDailyEncouragement(data);
    } catch (error) {
      console.error('Error fetching daily encouragement:', error);
    }
  };

  const handleMoodSelect = async (mood) => {
    console.log('Selected mood:', mood); // Debug log
    setSelectedMood(mood);
    setLoading(true);
    
    try {
      const response = await fetch(`${API_BASE_URL}/encouragement/${mood}`);
      
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      
      const data = await response.json();
      console.log('Encouragement response:', data); // Debug log
      setEncouragement(data);
    } catch (error) {
      console.error('Error fetching encouragement:', error);
      setEncouragement({
        message: "Sorry, I couldn't fetch encouragement right now. But remember, you're amazing! 💪",
        mood: mood
      });
    } finally {
      setLoading(false);
    }
  };

  const getAnotherMessage = () => {
    if (selectedMood) {
      handleMoodSelect(selectedMood);
    }
  };

  const getMoodEmoji = (mood) => {
    const emojiMap = {
      happy: '😊',
      sad: '😢',
      stressed: '😰',
      excited: '🤩',
      tired: '😴',
      anxious: '😟'
    };
    return emojiMap[mood] || '😊';
  };

  return (
    <div className="App">
      <div className="container">
        <header className="App-header">
          <h1>Mood Encouragement 🌟</h1>
          <p>Choose your mood and get personalized encouragement</p>
        </header>

        {/* Daily Encouragement */}
        {dailyEncouragement && (
          <div className="daily-encouragement">
            <h3>✨ Daily Inspiration</h3>
            <p>{dailyEncouragement.message}</p>
            <small>Your daily dose of motivation</small>
          </div>
        )}

        {/* Mood Selector */}
        <div className="mood-selector">
          <h2>How are you feeling today?</h2>
          <div className="mood-grid">
            {moods.map((mood) => (
              <button
                key={mood} // Fixed: Added unique key prop
                className={`mood-button ${selectedMood === mood ? 'selected' : ''}`}
                onClick={() => handleMoodSelect(mood)} // Fixed: Pass mood correctly
                disabled={loading}
              >
                <span className="mood-emoji">{getMoodEmoji(mood)}</span>
                <span className="mood-text">{mood}</span>
              </button>
            ))}
          </div>
        </div>

        {/* Loading */}
        {loading && (
          <div className="loading">
            <div className="spinner"></div>
            <p>Getting your personalized encouragement...</p>
          </div>
        )}

        {/* Encouragement Result */}
        {encouragement && !loading && (
          <div className="encouragement-result">
            <div className="encouragement-card">
              <h3>For when you're feeling {selectedMood} {getMoodEmoji(selectedMood)}</h3>
              <div className="encouragement-message">
                {encouragement.message || encouragement.Message}
              </div>
              <small>Remember: You've got this! 💪</small>
            </div>
            <button className="another-button" onClick={getAnotherMessage}>
              Get Another Message
            </button>
          </div>
        )}
      </div>
    </div>
  );
}

export default App;
