# Rocket Landing - Practice Exercise

## Assumptions
* In-memory store solution.
* No need to create a fixture class for initializing the dependencies. This is to mantain it is simple as possible. This is being initializated in the test class ctor.
* The landing area will always have a size of 100x100.
* The landing platform will always starts on position 5,5 and only the size will be variable (10x10, 5x5, 6x3...).
* The landing platform size never won't be  more than the max size (96x96).
* The input will be always have values between 0 and 100.
* When a rocket asks for landing it wont ask for another position. Won't ask for more than 1 position if the first check for the position is "ok for landing"

## Offtopic

Thinking on selling this to Elon Musk so he can finally land his rockets successfully (or not) (: