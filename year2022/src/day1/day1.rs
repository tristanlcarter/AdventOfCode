use std::env;
use std::fs;

pub fn day1(part: String) {
    let contents = fs::read_to_string("input.txt")
        .expect("Should have been able to read the file.");
    println!("{contents}");

    if part == "a" {
        part_a();
    }
    else if part == "b" {
        part_b();
    }

    return;
}

fn part_a(){
    println!("Noah is a bitch.\n")
}

fn part_b(){
    println!("Jacob is a bitch.\n")
}