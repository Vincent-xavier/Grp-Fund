import {StyleSheet} from 'react-native';
import React from 'react';
import {createNativeStackNavigator} from '@react-navigation/native-stack';
import OnboardingScreen from '../screens/onboarding';
import LoginScreen from '../screens/auth/login';

// Tab Navigation
import TabNavigation from './TabNavigation';

const Navigation = () => {
  const Stack = createNativeStackNavigator();
  return (
    <Stack.Navigator
      screenOptions={{
        headerShown: false,
      }}>
      <Stack.Screen name="Onboarding" component={OnboardingScreen} />
      <Stack.Screen name="Login" component={LoginScreen} />

      <Stack.Screen name="Home" component={TabNavigation} />
    </Stack.Navigator>
  );
};

export default Navigation;

const styles = StyleSheet.create({});
