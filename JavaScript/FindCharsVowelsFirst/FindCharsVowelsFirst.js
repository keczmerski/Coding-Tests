function vowelsAndConsonants(s) {
    const vowels = ['a','e','i','o','u']
    let vowelsFound = []
    let consonantsFound = []
    String(s).split('').forEach(character =>{
        if (vowels.includes(character)){
            vowelsFound.push(character)
        }
        else{
            if (character>'a' && character<'z'){
                consonantsFound.push(character)
            }
        }
    })

    vowelsFound.forEach(characterInVowels => {
        console.log(characterInVowels)
    })
    consonantsFound.forEach(characterInConstants => {
        console.log(characterInConstants)
    })

}
const s = "thisisathing"
vowelsAndConsonants(s)