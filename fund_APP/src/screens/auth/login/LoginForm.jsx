import {useNavigation} from '@react-navigation/native';
import InputField from '../../../components/form-controls/InputField';
import {useForm} from 'react-hook-form';
import {View, StyleSheet, Text, TouchableOpacity} from 'react-native';
import {Button} from 'react-native-paper';

const LoginForm = () => {
  const navigation = useNavigation();
  const {control, handleSubmit} = useForm({
    defaultValues: {email: 'test', password: 'test'},
  });

  const onSubmit = data => {
    alert(JSON.stringify(data));

    navigation.navigate('Home');
  };

  return (
    <View>
      <Text style={styles.inputLabel}>Email or Phone</Text>
      <InputField
        name="email"
        control={control}
        rules={{
          required: 'Email is required',
        }}
        placeholder="Enter Email or Phone"
      />

      <Text style={styles.inputLabel}>Password</Text>
      <InputField
        name="password"
        control={control}
        rules={{required: 'Password is required'}}
        placeholder="Enter your password"
        secureTextEntry
      />

      <View style={styles.forgotContainer}>
        <TouchableOpacity>
          <Text style={styles.forgotPassword}>Forgot Password?</Text>
        </TouchableOpacity>
      </View>

      <Button
        mode="contained"
        style={styles.loginButton}
        onPress={handleSubmit(onSubmit)}>
        LOGIN
      </Button>
    </View>
  );
};

export default LoginForm;

const styles = StyleSheet.create({
  inputLabel: {
    fontSize: 14,
    color: '#888',
    textAlign: 'left',
  },
  input: {
    borderWidth: 1,
    borderColor: '#ccc',
    borderRadius: 8,
    height: 50,
    paddingHorizontal: 15,
    marginVertical: 10,
  },
  forgotContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'flex-end',
    marginVertical: 10,
  },

  forgotPassword: {
    color: '#00b894',
  },
  loginButton: {
    marginVertical: 20,
    borderRadius: 8,
    paddingVertical: 8,
    backgroundColor: '#00b894',
  },
});
