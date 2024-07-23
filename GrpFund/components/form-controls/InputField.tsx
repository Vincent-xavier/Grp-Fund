import { useController } from "react-hook-form";
import { StyleSheet, Text, TextInput, View } from "react-native";

const InputField: React.FC<{
  name: string;
  control: any;
  rules?: any;
  placeholder?: string;
  secureTextEntry?: boolean;
}> = ({ name, control, rules, placeholder, secureTextEntry }) => {
  const { field, fieldState } = useController({
    name,
    control,
    rules,
  });

  return (
    <View>
      <TextInput
        style={[styles.input, fieldState.error && styles.errorBorder]}
        value={field.value}
        onBlur={field.onBlur}
        onChangeText={field.onChange}
        placeholder={placeholder}
        secureTextEntry={secureTextEntry}
      />
      {fieldState.error && (
        <Text style={styles.errorText}>{fieldState.error.message}</Text>
      )}
    </View>
  );
};

export default InputField;

const styles = StyleSheet.create({
  input: {
    borderWidth: 1,
    borderColor: "#ccc",
    borderRadius: 8,
    height: 50,
    paddingHorizontal: 15,
    marginVertical: 10,
  },
  errorBorder: {
    borderColor: "red",
  },
  errorText: {
    color: "red",
  },
});
