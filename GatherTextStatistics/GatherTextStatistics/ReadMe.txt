This is a coding challenge with the following requirements:

o Must be a a .Net Core 2.2 Console application 
o The process will download a text file from a URI or upload local file.
o using the text from the downloaded file, write statistics about that file to the console:
	o A count of each letter in the file (case insensitive)
		A file containing only the text "asdfASDFz" the result would be:
			A - 2
			D - 2
			F - 2
			S - 2
			Z - 1
	o A count of how many charactors in the file are capitalized.
	o Most common word:
		o The word itself
		o a count of the occurences
	o Prefixes:
		o the most common prefix regardless of length (see Deffinitions)
			o the prefix its self
			o a count of occurences
			o A comma seperated list of the words that contain the prefix(s)			

Definitions: 
o A word is a string of charactors where the first letter is capatilized and all subsiquent letters are lowercase. 
	o There are no white space charactors anticipated.
o A prefix is a substring of a word that includes at least the first two charactors and does not include all the charactors of a word.
	(The word "in" does not contain the prefix "in" but the word "indirectly" does.)
o An empty text file is one that contains no alphabetic letters.

Edge Cases:
o If the text file is empty, simply process it as normal, zeroed values should result.
o If a word contains charactors that are not letters they will be treated as lowercase charactors in the case of words and prefixes. 
	Therefore a file containing exactly "31462364" will result in a single word "31462364". 
	A file containing exactly "234J23 4" will have two words: "234", and "J23 4".
	Further, non letters will not be counted as part of prefixes. ( i.e.: "F2r345og" => "Frog") This is mostly because non letters are not expected at all.
o If there is more than one word or prefix that is tied for the most occurances 
	then the application will identify all the words or prefixes that have that count.
o prefixes of any length that are sub prefixes of the same prefix should not be counted as the same. 
	(i.e.:"PreasPreatPreah" => {"Prea"}; "PreasPreatPreah" !=> {"Pr","Pre","Prea"};)
o If there is only one word then count exactly one word.

