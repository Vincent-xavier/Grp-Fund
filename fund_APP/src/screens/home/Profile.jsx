import React from 'react';
import {View, Text, StyleSheet} from 'react-native';
import {
  Avatar,
  ProgressBar,
  IconButton,
  Card,
  Button,
  List,
} from 'react-native-paper';

const LeftContent = props => <Avatar.Icon {...props} icon="folder" />;

const Profile = () => {
  return (
    <View style={styles.container}>
      <View style={styles.profileHeader}>
        <View style={styles.profileInfo}>
          <Avatar.Image source={require('../../assets/images/avatar.png')} />
          <View style={styles.userInfo}>
            <Text style={styles.profileName}>John Doe</Text>
            <View>
              <ProgressBar progress={0.5} />
              <Text style={styles.progressText}>50% Completed</Text>
            </View>
          </View>
        </View>
        <IconButton
          mode="contained"
          containerColor="#343940"
          icon="pen"
          iconColor="#dce1e8"
          size={12}
          onPress={() => console.log('Pressed')}
        />
      </View>
      <View style={styles.contributionPanel}>
        <View style={styles.contributionInfo}>
          <View style={styles.contributionItem}>
            <Text style={styles.contributionLabel}>Contribution</Text>
            <Text style={styles.contributionValue}>$1000</Text>
          </View>
          <View style={styles.divider} />
          <View style={styles.contributionItem}>
            <Text style={styles.contributionLabel}>Donation</Text>
            <Text style={styles.contributionValue}>$1000</Text>
          </View>
        </View>
      </View>
      <View style={styles.settingsPanel}>
        <List.AccordionGroup>
          <List.Accordion title="Personal Info" id="1">
            <List.Item title="Item 1" />
          </List.Accordion>
          <List.Accordion title="Educational Info" id="2">
            <List.Item title="Item 2" />
          </List.Accordion>

          <List.Accordion title="Contact Info" id="3">
            <List.Item title="Item 3" />
          </List.Accordion>

          <List.Accordion title="Contributions" id="4">
            <List.Item title="Item 4" />
          </List.Accordion>

          <List.Accordion title="Change Password" id="5">
            <List.Item title="Item 5" />
          </List.Accordion>
        </List.AccordionGroup>
      </View>
    </View>
  );
};

export default Profile;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
  },
  profileHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    width: '100%',
    height: 200,
    backgroundColor: '#00b894',
    paddingHorizontal: 15,
  },
  divider: {
    width: 1,
    height: 50,
    backgroundColor: '#dce1e8',
  },
  profileInfo: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  userInfo: {
    marginLeft: 20,
    gap: 5,
  },
  profileName: {
    fontSize: 24,
    fontFamily: 'Poppins-SemiBold',
    fontWeight: '650',
    color: 'white',
  },
  progressText: {
    fontSize: 14,
    color: 'white',
  },
  contributionPanel: {
    backgroundColor: 'white',
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginTop: -25,
    width: '80%',
    padding: 15,
    borderRadius: 10,
    shadowColor: 'black',
    shadowOffset: {width: 0, height: 10},
    shadowRadius: 10,
    shadowOpacity: 0.1,
    height: 100,
  },
  contributionInfo: {
    flexDirection: 'row',
    justifyContent: 'space-evenly',
    alignItems: 'center',
    width: '100%',
  },
  contributionItem: {
    alignItems: 'center',
    gap: 4,
  },
  contributionLabel: {
    fontSize: 16,
    fontFamily: 'Poppins-SemiBold',
    fontWeight: '700',
  },
  contributionValue: {
    fontSize: 18,
    fontFamily: 'Poppins-SemiBold',
    fontWeight: '650',
    color: '#00b894',
  },
  settingsPanel: {
    width: '100%',
    top: 20,
  },
});
