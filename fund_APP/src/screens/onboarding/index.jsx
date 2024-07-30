import {StyleSheet, Text, View} from 'react-native';
import React from 'react';

import Onboarding from 'react-native-onboarding-swiper';
import LottieView from 'lottie-react-native';
import {useNavigation} from '@react-navigation/native';

const OnboardingScreen = () => {
  const navigation = useNavigation();

  const handleSkip = () => {
    navigation.navigate('Login');
  };
  return (
    <Onboarding
      bottomBarHighlight={false}
      showDone={true}
      showNext={true}
      showSkip={true}
      onDone={() => {
        handleSkip();
      }}
      onSkip={() => {
        handleSkip();
      }}
      pages={[
        {
          backgroundColor: '#fff',
          image: (
            <LottieView
              autoPlay
              style={styles.lottie}
              source={require('../../assets/animations/onboarding1.json')}
            />
          ),
          title: 'Welcome to Grp Funds!',
          subtitle:
            "Ready to make managing group funds simple and stress-free? Let's get started!",
        },
        {
          backgroundColor: '#fff',
          image: (
            <LottieView
              autoPlay
              style={styles.lottie}
              source={require('../../assets/animations/onboarding3.json')}
            />
          ),
          title: 'Collect Contributions',
          subtitle:
            'Invite members to contribute to the group fund with just a few taps. Transparent and hassle-free!',
        },
        {
          backgroundColor: '#fff',
          image: (
            <LottieView
              autoPlay
              style={styles.lottie}
              source={require('../../assets/animations/onboarding2.json')}
            />
          ),

          title: 'Track Expenses',
          subtitle:
            'Keep a record of every transaction. Ensure everyone knows where the money goes, every step of the way.',
        },
      ]}
    />
  );
};

export default OnboardingScreen;

const styles = StyleSheet.create({
  imageContainerStyles: {
    padding: 0,
  },
  lottie: {
    width: 240,
    height: 240,
  },
});
