import {NavigationContainer} from '@react-navigation/native';
import Navigation from './src/navigation';
import React, {useEffect, useState} from 'react';
import {asyncStorage} from 'react-native';
import {PaperProvider} from 'react-native-paper';

function App() {
  const [isFirstLoad, setIsFirstLoad] = useState(false);

  useEffect(() => {
    if (isFirstLoad) {
      checkFirstLoad();
    }
  }, []);

  async function checkFirstLoad() {
    try {
      const value = await asyncStorage.getItem('firstLoad');
      if (value === null) {
        setIsFirstLoad(true);
        asyncStorage.setItem('firstLoad', 'true');
      } else {
        setIsFirstLoad(false);
      }
    } catch (e) {
      console.log(e);
    }
  }

  return (
    <PaperProvider>
      <NavigationContainer>
        <Navigation isFirstLoad={isFirstLoad} />
      </NavigationContainer>
    </PaperProvider>
  );
}

export default App;
