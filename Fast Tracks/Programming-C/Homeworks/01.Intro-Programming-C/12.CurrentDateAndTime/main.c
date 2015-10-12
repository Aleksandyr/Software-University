/* 
 * File:   main.c
 * Author: alexander
 *
 * Created on October 12, 2015, 5:44 PM
 */

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

/*
 * 
 */
int main(int argc, char** argv) {

    time_t rawtime;
    struct tm * timeinfo;

    time ( &rawtime );
    timeinfo = localtime ( &rawtime );
    printf ( "Current local time and date: %s", asctime (timeinfo) );

    return (EXIT_SUCCESS);
}

