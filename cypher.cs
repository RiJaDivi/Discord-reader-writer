source ./keys.txt

ARGS=("$@")

if [ "${ARGS[0]}" == "-e" ]
then
	M=$(python3 -c "
	import sys
	s = sys.argv[1]
	print(int.from_bytes(s.encode(), 'big'))
	" "${ARGS[*]:1}")

	C=$(python3 -c "print(pow($M, $E, $N))")
	echo $C
elif [ "${ARGS[0]}" == "-d" ]
then
	C=$2
	M=$(python3 -c "print(pow($C, $D, $N))")
	TEXT=$(python3 -c "
	n = int('$M')
	print(n.to_bytes((n.bit_length() + 7) // 8, 'big').decode())")
	echo $TEXT
fi
