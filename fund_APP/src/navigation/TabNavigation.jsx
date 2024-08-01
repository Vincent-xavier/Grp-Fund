import React from 'react';
import {StyleSheet} from 'react-native';
import {createBottomTabNavigator} from '@react-navigation/bottom-tabs';

// components
import BottomBar from '../components/navigation/BottomBar';

// screens
import HomeScreen from '../screens/home';
import Transaction from '../screens/home/Transactions';
import profile from '../screens/home/Profile';

const TabNavigation = () => {
  const Tab = createBottomTabNavigator();
  return (
    <Tab.Navigator
      tabBar={props => <BottomBar {...props} />}
      screenOptions={{headerShown: false}}
      initialRouteName="index">
      <Tab.Screen
        name="index"
        component={HomeScreen}
        options={{
          title: 'Home',
        }}
      />
      <Tab.Screen
        name="transactions"
        component={Transaction}
        options={{
          title: 'Transactions',
        }}
      />
      <Tab.Screen
        name="profile"
        component={profile}
        options={{
          title: 'Profile',
        }}
      />
    </Tab.Navigator>
  );
};

export default TabNavigation;

const styles = StyleSheet.create({});
