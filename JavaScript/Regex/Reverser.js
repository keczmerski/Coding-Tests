function reverseString(s) {
    if (s.length === undefined) {
        console.log("Value is not a string, returning value.")
        return s
    }
    let stringToBeLogged
    let reverse = []
    for(let i = s.length - 1; i >= 0; i--){
        reverse.push(s[i])
    }
    stringToBeLogged = reverse.join('')

    return stringToBeLogged
}
console.log("Try reversing Frog")
console.log(reverseString("frog"))
console.log("Try reversing a number")
console.log(reverseString(Number(1234)))