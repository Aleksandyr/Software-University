/* 
 * File:   main.c
 * Author: alexander
 *
 * Created on October 12, 2015, 5:27 PM
 */

#include <stdio.h>
#include <stdlib.h>

/*
 * 
 */
int main(int argc, char** argv) {
    int i;
    int n;
    scanf("%d", &n);
    
    for(i = 2; i <= n + 1; i++){
        if(i % 2 != 0){
            printf("%d", -i);
        } 
        else{
            printf("%d", i);
        }
        if(i != n + 1){
            printf(", ");
        }
    }

    return (EXIT_SUCCESS);
}

