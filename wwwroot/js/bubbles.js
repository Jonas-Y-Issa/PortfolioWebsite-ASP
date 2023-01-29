window.onload = () =>{
    let container = document.querySelector("#backdrop");
    let bubbles = document.querySelectorAll(".stack_img");

    container.width = innerWidth;
    container.height = innerHeight;

class Bubble{
    constructor(speed, friction, bubble, ind){
        this.speed = speed;
        this.friction = friction;
        this.bubble = bubble;
        this.ind = ind;
        //this.positionCurve();
        //this.positionDefault();
        //this.positionQuadratic(ind);
        this.positionQuadratic(ind*0.1);
    }
    positionCurve(){
        this.bubble.style.top = this.ind * 84 + "px";
        this.bubble.style.left = 
        (container.width )
        -(84*(container.width/Math.abs(container.height-this.bubble.offsetTop)))
        + "px";
    }    
    positionDefault(){
        this.bubble.style.top = (1.5+this.ind) * 90 + "px";
        this.bubble.style.left = container.width - 120 +"px";
    }
    positionQuadratic(i){
        var x1 = container.width-(this.bubble.clientWidth);
        var y1 = 0;
        var x2 = container.width-(this.bubble.clientWidth);
        var y2 = container.height-(this.bubble.clientHeight);
        var x3 = 0;
        var y3 = container.height-(this.bubble.clientHeight);
        var xa = this.getPt(x1, x2, i);
        var ya = this.getPt(y1, y2, i);
        var xb = this.getPt(x2, x3, i);
        var yb = this.getPt(y2, y3, i);
    
        var y = this.getPt(xa ,xb ,i);
        var x = this.getPt(ya ,yb ,i);
        this.bubble.style.top = x + "px";
        this.bubble.style.left = y + "px";
    }
    moveQuadratic(i){
        var x1 = container.width-(this.bubble.clientWidth);
        var y1 = 0;
        var x2 = container.width-(this.bubble.clientWidth);
        var y2 = container.height-(this.bubble.clientHeight);
        var x3 = 0;
        var y3 = container.height-(this.bubble.clientHeight);
        var xa = this.getPt(x1, x2, i);
        var ya = this.getPt(y1, y2, i);
        var xb = this.getPt(x2, x3, i);
        var yb = this.getPt(y2, y3, i);
    
        var y = this.getPt(xa ,xb ,i);
        var x = this.getPt(ya ,yb ,i);
        this.bubble.style.top = x + "px";
        this.bubble.style.left = y + "px";
    }
    getPt(n1, n2, perc){
        var diff = n2 - n1;
        return n1 + (diff * perc);
    }   
    move(){
        if (this.bubble.offsetTop >= container.height - this.bubble.clientHeight){ 
            this.speed = 0;
        }
        else{
            this.speed+=0.008;
            this.moveQuadratic(this.speed+(this.ind*0.1));
        }
    }
}
    let bubble_list = [];
    var i = -1;
    bubbles.forEach(bubble => {
        i += 1;
        bubble_list.push(new Bubble(0,.3, bubble, i));
    });

    function animate(){
        requestAnimationFrame(animate);
        bubble_list.forEach(bubble => {
            bubble.move();
        });
    }
    animate();
}