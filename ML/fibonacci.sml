(*
 Author: http://lemming.life
 Description: A simple fibonacci function using pattern matching.
*)

fun fib(0) = 0
|   fib(1) = 1
|   fib(n) = fib(n-2) + fib(n-1);