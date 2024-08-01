import React from 'react';
import {View, Text, StyleSheet, FlatList} from 'react-native';
import {
  Appbar,
  Avatar,
  IconButton,
  Searchbar,
  Button,
} from 'react-native-paper';

export default function Transaction() {
  const renderTransaction = ({item}) => (
    <View style={styles.transactionItem}>
      <Avatar.Icon
        size={40}
        icon={item.icon}
        style={{backgroundColor: '#eee'}}
      />
      <View style={styles.transactionDetails}>
        <Text style={styles.transactionName}>{item.name}</Text>
        <Text style={styles.transactionCategory}>
          {item.time} - {item.category}
        </Text>
      </View>
      <Text style={styles.transactionAmount}>{item.amount}</Text>
    </View>
  );

  return (
    <View style={styles.container}>
      <Appbar.Header>
        <Appbar.Content title="Transactions" style={styles.title} />
        <Appbar.Action icon="filter" style={styles.icon} onPress={() => {}} />
      </Appbar.Header>
      <Searchbar placeholder="Search" style={styles.searchbar} />
      <FlatList
        data={transactions}
        renderItem={renderTransaction}
        keyExtractor={item => item.id}
        style={styles.transactionsList}
      />
    </View>
  );
}

const transactions = [
  {
    id: '1',
    name: 'Intelligentsia Coffee',
    amount: '$10.95',
    time: '8:24 pm',
    category: 'Restaurants & cafes',
    icon: 'coffee',
  },
  {
    id: '2',
    name: 'Uber',
    amount: '$20.47',
    time: '1:12 pm',
    category: 'Transport',
    icon: 'car',
  },
  {
    id: '3',
    name: 'Far Media Inc.',
    amount: '+$200.00',
    time: '9:20 am',
    category: 'Paychecks',
    icon: 'bank',
  },
  {
    id: '4',
    name: 'Airbnb',
    amount: '$258.65',
    time: '9:53 pm',
    category: 'Hotels & rent',
    icon: 'home',
  },
  {
    id: '5',
    name: 'Netflix',
    amount: '$39.99',
    time: '9:00 pm',
    category: 'Media & telecom',
    icon: 'film',
  },
  {
    id: '6',
    name: "Big Papa's Grocery Shop",
    amount: '$15.38',
    time: '4:46 pm',
    category: 'Food & groceries',
    icon: 'store',
  },
  {
    id: '7',
    name: 'Shell Gas Station',
    amount: '$103.75',
    time: '10:03 am',
    category: 'Transport',
    icon: 'gas-station',
  },
];

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },

  title: {
    fontSize: 20,
    fontWeight: 'bold',
    marginLeft: 10,
  },
  searchbar: {
    margin: 10,
  },

  transactionsList: {
    flex: 1,
  },
  transactionItem: {
    flexDirection: 'row',
    alignItems: 'center',
    padding: 10,
    borderBottomWidth: 1,
    borderBottomColor: '#eee',
  },
  transactionDetails: {
    flex: 1,
    marginLeft: 10,
  },
  transactionName: {
    fontSize: 16,
  },
  transactionCategory: {
    fontSize: 12,
    color: '#888',
  },
  transactionAmount: {
    fontSize: 16,
    fontWeight: 'bold',
  },
});
