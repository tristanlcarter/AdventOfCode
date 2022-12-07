mod day1;

use day1::day1::day1;
use std::fs;
use std::io;
use std::io::stdin;

fn main() {
    println!("Welcome to the Advent of Code, 2022!");
    loop {
        println!("\nEnter the day or type 'quit': ");
        let day = grab_user_input();
        if day.trim() == "quit" {break;}

        println!("\nEnter the part (a or b):");
        let part = grab_user_input().trim().to_lowercase();

        call_day_function(day, part);
    }

    return;
}

fn call_day_function(day: String, part: String){
    match day.trim() {
        "1" => day1(part),
        _ => println!("!! THAT DAY IS NOT VALID !!"),
    };
}

fn grab_user_input() -> String{
    let mut day = String::new();
    stdin().read_line(&mut day);

    return day;
}
