source ./keys.txt
C=1923208066296951072

M=$(python3 -c "print(pow($C, $D, $N))")
echo $M
