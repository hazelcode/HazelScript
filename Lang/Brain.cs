using System;

namespace HazelScript.Lang;

public class Brain {
    public static void BubbleMethod(ref int[] ar){
        bool flag = true;
        for(int i = 0; i < ar.Length && flag; i++){
            flag = false;
            for(int j = 0; j < ar.Length-i-1; j++){
                if(ar[j] > ar[j+1]){
                    flag = true;
                    int aux = ar[j];
                    ar[j] = ar[j+1];
                    ar[j+1] = aux;
                }
            }
        }
    }
    public static void BubbleMethod(ref string[] ar){
        bool flag = true;
        for(int i = 0; i < ar.Length && flag; i++){
            flag = false;
            for(int j = 0; j < ar.Length-i-1; j++){
                if(ar[j].Length > ar[j+1].Length){
                    flag = true;
                    string aux = ar[j];
                    ar[j] = ar[j+1];
                    ar[j+1] = aux;
                }
            }
        }
    }
    public static bool BinarySearch(int[] ar, int search){
        int low = 0, middle = 0, high = ar.Length-1;
        bool flag = false;
        while(low <= high){
            middle = (high + low)/2;
            if(ar[middle] == search){
                flag = true;
                break;
            } else if(search < ar[middle]){
                high = middle-1;
            } else {
                low = middle+1;
            }
        }
        return flag;
    }
    public static bool BinarySearch(string[] ar, string search){
        int low = 0, middle = 0, high = ar.Length-1;
        bool flag = false;
        while(low <= high){
            middle = (high + low)/2;
            if(ar[middle] == search || ar[low] == search || ar[high] == search){
                flag = true;
                break;
            } else {
                high = middle-1;
                low = middle+1;
            }
        }
        return flag;
    }
}