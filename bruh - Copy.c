int main(){
	int i=2;
	int rc=fork();
	if (rc==0) {
		i+=5;
		printf("i=%d \n",i);	
	}
	if (rc>0) {
		rc=fork();
		if (rc==0) {i+=3};
		i--;
		printf("i=%d \n",i);	
	}
return 0;
}
