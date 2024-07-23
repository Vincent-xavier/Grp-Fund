import { View, StyleSheet, Image, Text, TouchableOpacity } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";

import LoginForm from "./LoginForm";

export default function LoginScreen() {
  return (
    <SafeAreaView style={styles.container}>
      <View style={styles.container}>
        <View style={styles.topSection}>
          <Image
            source={{ uri: "https://your-image-url" }} // Replace with your image URL or local image path
            style={styles.image}
          />
        </View>
        <View style={styles.bottomSection}>
          <Text style={styles.title}>Login to your account</Text>

          <LoginForm />

          <TouchableOpacity>
            <Text style={styles.registerText}>
              Don't have an account? Register here
            </Text>
          </TouchableOpacity>
        </View>
      </View>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#f0f0f0",
  },
  topSection: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: "#00b894",
    borderBottomLeftRadius: 50,
    borderBottomRightRadius: 50,
  },
  image: {
    width: 150,
    height: 150,
  },
  bottomSection: {
    flex: 2,
    padding: 20,
  },
  title: {
    fontSize: 24,
    fontWeight: "bold",
    marginBottom: 20,
    textAlign: "center",
  },
  registerText: {
    textAlign: "center",
    color: "#00b894",
  },
});
